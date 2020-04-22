using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Cold_Clear_SF
{
    public partial class CC : Form
    {
        public CC()
        {
            InitializeComponent();
        }
        Color[] minocolor = { Color.White, Color.Gray, Color.Aqua, Color.Purple, Color.Yellow, Color.LawnGreen, Color.Red, Color.Orange, Color.Blue };
        Label[] Field = new Label[220];
        int paintmode1 = 0;
        bool restflag = false;

        private void updatefield()
        {
            foreach (Label i in Field)
            {
                i.BackColor = minocolor[(int)i.Tag];
            }
        }
        private void clearALL()
        {
            foreach (Label i in Field)
            {
                i.Tag = 0;
                i.BackColor = Color.White;
            }
            holdb.Text = "hold: ";
            Nexttt.Text = "Next: ";
            hold = -1;
            combo = 0;
            nexttab = null;
            if (ptrBot != (IntPtr)null)
                coldclearcore.cc_destroy_async(ptrBot);
            ptrBot = (IntPtr)null;
        }
        uint combo = 0;
        private void line_clear()
        {
            bool[] cleartag = new bool[22];
            for (int i = 0; i < 22; ++i)
            {
                bool flag = true;
                for (int j = 0; j < 10; ++j)
                {
                    if ((int)Field[j + i * 10].Tag == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    cleartag[i] = true;
                }
            }
            foreach (bool i in cleartag)
            {
                if (i)
                {
                    combo += 1;
                }
                else
                {
                    combo = 0;
                }
            }
            int index = 0;
            for (int i = 0; i < 22; ++i, ++index)
            {
                //if (cleartag[i])
                //{
                //    cleartag[i] = false;
                //    while (index < 21 && cleartag[++index])
                //    {
                //        cleartag[index] = false;
                //    }
                //}
                if (index < 22 && cleartag[index])
                {
                    cleartag[index] = false;
                    while (index < 21 && cleartag[++index])
                    {
                        cleartag[index] = false;
                    }
                }
                if (index != i)
                    for (int j = 0; j < 10; ++j)
                    {
                        if (index < 22)
                        {
                            Field[i * 10 + j].Tag = Field[index * 10 + j].Tag;
                            Field[index * 10 + j].Tag = 0;
                        }
                        else
                            Field[i * 10 + j].Tag = 0;
                    }
                if (index < 22)
                    cleartag[i] = cleartag[index];
                else
                    cleartag[i] = false;
            }
            updatefield();
        }

        private void CC_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 220; ++i)
            {
                Field[i] = new Label();
                Field[i].Width = 30;
                Field[i].Height = 28;
                Field[i].Left = Width / 2 - 30 * 5 + (i % 10) * 29;
                Field[i].Top = Height / 2 - 70 + 30 * 11 - (i / 10) * 27;
                Field[i].BorderStyle = BorderStyle.FixedSingle;
                Field[i].BackColor = Color.White;
                Field[i].Visible = true;
                Field[i].Tag = 0;
                Field[i].Click += new EventHandler(CC_Click);
                Field[i].MouseMove += CC_MouseMove;
                Controls.Add(Field[i]);
            }

            //cCWeights.tslot = new int[4];
            //cCWeights.well_column = new int[10];

            //unsafe {
            //CCWeights* cCWeights = null;


            //}

        }

        private void CC_MouseMove(object sender, MouseEventArgs e)
        {
            if (paintmode1 == 0) return;
            if (paintmode1 == 1)
            {
                restflag = true;
                ((Label)sender).Tag = 1;
                ((Label)sender).BackColor = Color.Gray;
            }
            if (paintmode1 == 2)
            {
                restflag = true;
                ((Label)sender).Tag = 0;

                ((Label)sender).BackColor = Color.White;

            }
        }

        private void CC_Click(object sender, EventArgs e)
        {

            if ((int)((Label)sender).Tag != 0)
            {
                ((Label)sender).Tag = 0;
                restflag = true;
                ((Label)sender).BackColor = Color.White;
            }
            else
            {
                ((Label)sender).Tag = 1;
                restflag = true;
                ((Label)sender).BackColor = Color.Gray;
            }
            //throw new NotImplementedException();
        }

        private void CC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                if (paintmode1 == 1)
                {
                    Mode.Text = "微调模式";
                    paintmode1 = 0;
                }
                else
                {
                    Mode.Text = "涂地模式";
                    paintmode1 = 1;
                }

            }
            if (e.KeyCode == Keys.C)
            {
                if (paintmode1 == 2)
                {
                    Mode.Text = "微调模式";
                    paintmode1 = 0;
                }
                else
                {
                    Mode.Text = "擦除模式";
                    paintmode1 = 2;
                }

            }
        }

        private void CC_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CC_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void lineclear_Click(object sender, EventArgs e)
        {
            line_clear();
        }
        string[] block = { "I", "T", "O", "S", "Z", "L", "J" };
        private void clearall_Click(object sender, EventArgs e)
        {
            clearALL();
        }
        IntPtr ptrBot = (IntPtr)(null);
        Queue<int> nexttab = null;
        int hold = -1;


        private void print_npiece()
        {
            line_clear();

            calc.Text = "计算";
            char[] clearflag = new char[23];
            bool[] cleartrue = new bool[23];

            IntPtr ptrmove = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCMove)));
            while (nexttab.Count > 0)
            {
                coldclearcore.cc_request_next_move(ptrBot, 0);
                Thread.Sleep(500);
                int nowb = nexttab.Dequeue();
                int limit = 0;
                while (!coldclearcore.cc_poll_next_move(ptrBot, ptrmove) && limit < 40)
                {
                    Thread.Sleep(100);
                    limit++;
                }
                if (limit == 40)
                {
                    //char[] f = new char[400];
                    //for (int i = 0; i < 220; ++i)
                    //{
                    //    if ((int)(Field[i].Tag) != 0)
                    //    {
                    //        f[i] = (char)(1);
                    //    }
                    //}
                    //coldclearcore.cc_reset_async(ptrBot, f, (char)(0), combo);
                    return;
                }
                CCMove cCMove = (CCMove)Marshal.PtrToStructure(ptrmove, typeof(CCMove));


                nodes.Text = "nodes: " + cCMove.nodes;
                if (cCMove.hold == 1)
                {

                    if (hold == -1)
                    {


                        hold = nowb;
                        holdb.Text = "hold: " + block[hold];
                        if (nexttab.Count <= 0) return;
                        nowb = nexttab.Dequeue();
                    }
                    else
                    {
                        int temp;
                        temp = nowb;
                        nowb = hold;
                        hold = temp;
                        holdb.Text = "hold: " + block[hold];
                    }
                }
                unsafe
                {


                    for (int i = 0; i < 4; ++i)
                    {
                        int cnt = 0;
                        for (int _ = 0; _ < 22; ++_)
                        {
                            if (!cleartrue[_]) cnt++;

                            if (cnt == cCMove.expected_y[i] + 1)
                            {
                                cCMove.expected_y[i] = (char)_;
                                break;
                            }
                        }

                        Field[(cCMove.expected_x[i]) + (cCMove.expected_y[i]) * 10].Tag = nowb + 2;
                        Field[(cCMove.expected_x[i]) + (cCMove.expected_y[i]) * 10].BackColor = minocolor[nowb + 2];
                        //Field[0].BackColor = Color.Purple
                    }


                }
                for (int q = 0; q < 22; ++q)
                {

                    bool flag = true;
                    for (int j = 0; j < 10; ++j)
                    {
                        if ((int)Field[j + q * 10].Tag == 0)
                        {
                            flag = false;
                            break;
                        }
                    }

                    //if (flag && !cleartrue[q])
                    //{

                    //    for (int zqd = q; zqd < 22; ++zqd)
                    //        clearflag[zqd] += (char)1;
                    //}
                    if (flag) cleartrue[q] = true;
                }
                string a = "";
                foreach (int i in nexttab)
                {
                    a += block[i];

                }
                Nexttt.Text = "Next: " + a;
                //Field[0].Tag = 1;
                //Field[0].BackColor = Color.Purple;
                //nexttab.Dequeue();
                //Thread.Sleep(2000);
                //break;

            }

        }
        private void calc_Click(object sender, EventArgs e)
        {
            line_clear();
            IntPtr ptrW = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCWeights)));
            coldclearcore.cc_default_weights(ptrW);
            CCWeights cCWeights = (CCWeights)Marshal.PtrToStructure(ptrW, typeof(CCWeights));
            IntPtr ptrOP = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCOptions)));
            coldclearcore.cc_default_options(ptrOP);
            CCOptions cCOptions = (CCOptions)Marshal.PtrToStructure(ptrOP, typeof(CCOptions));
            cCOptions.speculate = (char)(0);
            cCOptions.min_nodes = 200000;
            //cCOptions.max_nodes = 50000000;
            //Marshal.StructureToPtr(cCOptions, ptrOP, true);
            //Marshal.StructureToPtr(cCWeights, ptrW, true);
            //ptrBot = coldclearcore.cc_launch_async(ptrOP, ptrW);
            if (ptrBot == (IntPtr)null)
            {
                foreach (string key in ConfigurationManager.AppSettings.AllKeys)
                {
                    if (key == "tslot" || key == "well_column" || key == "min_nodes" || key == "use_hold"
                        || key == "mode" || key == "use_bag" || key == "threads")
                    {
                        continue;
                    }
                    //string ConfigPath = ConfigurationManager.AppSettings["ConfigPath"].Trim().ToString();
                    Configuration config1 = System.Configuration.ConfigurationManager.OpenExeConfiguration("Cold Clear SF.exe");

                    if (config1.AppSettings.Settings[key].Value == "")
                    {
                        config1.AppSettings.Settings.Add(key, cCWeights.GetType().GetField(key).GetValue(cCWeights).ToString());
                        config1.Save(ConfigurationSaveMode.Modified);
                    }

                    cCWeights.GetType().GetField(key).SetValue(cCWeights, int.Parse (config1.AppSettings.Settings[key].Value));
                }
                Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration("Cold Clear SF.exe");
                cCOptions.min_nodes = ulong.Parse( config.AppSettings.Settings["min_nodes"].Value);
                //cCOptions.threads = ulong.Parse(config.AppSettings.Settings["threads"].Value);
                cCOptions.mode = (CCMovementMode)Enum.Parse(typeof(CCMovementMode),  "CC_" + config.AppSettings.Settings["mode"].Value);
                cCOptions.use_hold = (char)(char.Parse(config.AppSettings.Settings["use_hold"].Value) - '0');
                string [] ts = config.AppSettings.Settings["tslot"].Value.Split(',');
                //cCWeights.use_bag = (char) (char.Parse(config.AppSettings.Settings["use_bag"].Value) - '0');
                string[] cw = config.AppSettings.Settings["well_column"].Value.Split(',');
                unsafe { 
                for (int i = 0; i < 4; ++i)
                {
                    cCWeights.tslot[i] = int.Parse(ts[i]);
                }
                    for (int i = 0; i < 10; ++i)
                    {
                        cCWeights.well_column[i] = int.Parse(cw[i]);
                    }
                }
                ptrBot = coldclearcore.cc_launch_async(cCOptions, cCWeights);
                Thread.Sleep(500);
            }

            char[] f = new char[400];
            for (int i = 0; i < 220; ++i)
            {
                if ((int)(Field[i].Tag) != 0)
                {
                    f[i] = (char)(1);
                }
            }
            coldclearcore.cc_reset_async(ptrBot, f, (char)(0), combo);
            //coldclearcore.cc_destroy_async(ptrBot);
            if (nexttab == null)
                nexttab = new Queue<int>();
            //hold = -1;
            foreach (char mino in nextqueue.Text.ToUpper())
            {
                //nexttab.Enqueue(1);
                //coldclearcore.cc_add_next_piece_async(ptrBot, CCPiece.CC_T);
                nexttab.Enqueue((int)Enum.Parse(typeof(CCPiece), "CC_" + mino));
                coldclearcore.cc_add_next_piece_async(ptrBot, (CCPiece)Enum.Parse(typeof(CCPiece), "CC_" + mino));

            }
            string a = "";
            foreach (int i in nexttab)
            {
                a += block[i];

            }
            Nexttt.Text = "Next: " + a;
            calc.Text = "计算完毕";
            //while (nexttab.Count > 1)
            //{
            //    coldclearcore.cc_request_next_move(ptrBot, 0);
            //    Thread.Sleep(1000);
            //    while (!coldclearcore.cc_poll_next_move(ptrBot, ptrmove))
            //    {
            //        Thread.Sleep(100);
            //    }
            //    CCMove cCMove = (CCMove)Marshal.PtrToStructure(ptrmove, typeof(CCMove));
            //    int nowb = nexttab.Dequeue();
            //    if (cCMove.hold == 1)
            //    {

            //        if (hold == -1)
            //        {
            //            if (nexttab.Count < 0) break;
            //            hold = nowb;
            //            nowb = nexttab.Dequeue();
            //        }
            //        else
            //        {
            //            int temp;
            //            temp = nowb;
            //            nowb = hold;
            //            hold = temp;
            //        }
            //    }
            //    unsafe
            //    {
            //        for (int i = 0; i < 4; ++i)
            //        {
            //            Field[(cCMove.expected_x[i]) + cCMove.expected_y[i] * 10].Tag = nowb + 2;
            //            Field[(cCMove.expected_x[i]) + cCMove.expected_y[i] * 10].BackColor = minocolor[nowb + 2];
            //            //Field[0].BackColor = Color.Purple;
            //        }
            //    }
            //    //Field[0].Tag = 1;
            //    //Field[0].BackColor = Color.Purple;
            //    //nexttab.Dequeue();
            //    //Thread.Sleep(2000);
            //    //break;
            //    line_clear();
            //}




        }

        private void nextmove_Click(object sender, EventArgs e)
        {
            line_clear();
            calc.Text = "计算";

            IntPtr ptrmove = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CCMove)));
            if (nexttab.Count > 0)
            {
                coldclearcore.cc_request_next_move(ptrBot, 0);
                Thread.Sleep(500);
                int limit = 0;
                int nowb = nexttab.Dequeue();
                while (!coldclearcore.cc_poll_next_move(ptrBot, ptrmove) && limit < 40)
                {
                    Thread.Sleep(100);
                    limit++;
                }
                nodes.Text = limit.ToString();
                if (limit == 40) {
                    //char[] f = new char[400];
                    //for (int i = 0; i < 220; ++i)
                    //{
                    //    if ((int)(Field[i].Tag) != 0)
                    //    {
                    //        f[i] = (char)(1);
                    //    }
                    //}
                    //coldclearcore.cc_reset_async(ptrBot, f, (char)(0), combo);
                    return;
                };
                CCMove cCMove = (CCMove)Marshal.PtrToStructure(ptrmove, typeof(CCMove));


                nodes.Text = "nodes: " + cCMove.nodes;
                if (cCMove.hold == 1)
                {

                    if (hold == -1)
                    {


                        hold = nowb;
                        holdb.Text = "hold: " + block[hold];
                        if (nexttab.Count <= 0) return;
                        nowb = nexttab.Dequeue();
                    }
                    else
                    {
                        int temp;
                        temp = nowb;
                        nowb = hold;
                        hold = temp;
                        holdb.Text = "hold: " + block[hold];
                    }
                }
                unsafe
                {
                    for (int i = 0; i < 4; ++i)
                    {
                        Field[(cCMove.expected_x[i]) + cCMove.expected_y[i] * 10].Tag = nowb + 2;
                        Field[(cCMove.expected_x[i]) + cCMove.expected_y[i] * 10].BackColor = minocolor[nowb + 2];
                        //Field[0].BackColor = Color.Purple;
                    }
                }
                string a = "";
                foreach (int i in nexttab)
                {
                    a += block[i];

                }
                Nexttt.Text = "Next: " + a;
                //Field[0].Tag = 1;
                //Field[0].BackColor = Color.Purple;
                //nexttab.Dequeue();
                //Thread.Sleep(2000);
                //break;

            }
        }

        private void holdb_Click(object sender, EventArgs e)
        {

        }

        private void daochu_Click(object sender, EventArgs e)
        {
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < 220; ++i)
            {
                a.AppendFormat("{0}", (int)Field[i].Tag);
            }
            fielddata.Text = a.ToString();
        }

        private void daoru_Click(object sender, EventArgs e)
        {
            clearALL();
            for (int i = 0; i < fielddata.Text.Length; ++i)
            {
                Field[i].Tag = (int)(fielddata.Text[i] - '0');
            }
            updatefield();
        }

        private void printall_Click(object sender, EventArgs e)
        {
            print_npiece();
        }
    }
}