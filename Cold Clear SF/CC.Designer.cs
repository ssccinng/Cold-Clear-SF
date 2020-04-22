namespace Cold_Clear_SF
{
    partial class CC
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Mode = new System.Windows.Forms.Label();
            this.lineclear = new System.Windows.Forms.Button();
            this.clearall = new System.Windows.Forms.Button();
            this.nextqueue = new System.Windows.Forms.TextBox();
            this.calc = new System.Windows.Forms.Button();
            this.nextmove = new System.Windows.Forms.Button();
            this.holdb = new System.Windows.Forms.Label();
            this.nodes = new System.Windows.Forms.Label();
            this.fielddata = new System.Windows.Forms.TextBox();
            this.daochu = new System.Windows.Forms.Button();
            this.daoru = new System.Windows.Forms.Button();
            this.Nexttt = new System.Windows.Forms.Label();
            this.printall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Mode
            // 
            this.Mode.AutoSize = true;
            this.Mode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Mode.Location = new System.Drawing.Point(672, 43);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(72, 16);
            this.Mode.TabIndex = 1;
            this.Mode.Text = "微调模式";
            // 
            // lineclear
            // 
            this.lineclear.Location = new System.Drawing.Point(699, 505);
            this.lineclear.Name = "lineclear";
            this.lineclear.Size = new System.Drawing.Size(75, 23);
            this.lineclear.TabIndex = 2;
            this.lineclear.Text = "消行";
            this.lineclear.UseVisualStyleBackColor = true;
            this.lineclear.Click += new System.EventHandler(this.lineclear_Click);
            this.lineclear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // clearall
            // 
            this.clearall.Location = new System.Drawing.Point(699, 545);
            this.clearall.Name = "clearall";
            this.clearall.Size = new System.Drawing.Size(75, 23);
            this.clearall.TabIndex = 2;
            this.clearall.Text = "全清";
            this.clearall.UseVisualStyleBackColor = true;
            this.clearall.Click += new System.EventHandler(this.clearall_Click);
            this.clearall.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // nextqueue
            // 
            this.nextqueue.Location = new System.Drawing.Point(699, 575);
            this.nextqueue.Name = "nextqueue";
            this.nextqueue.Size = new System.Drawing.Size(100, 21);
            this.nextqueue.TabIndex = 3;
            // 
            // calc
            // 
            this.calc.Location = new System.Drawing.Point(699, 602);
            this.calc.Name = "calc";
            this.calc.Size = new System.Drawing.Size(75, 23);
            this.calc.TabIndex = 2;
            this.calc.Text = "计算";
            this.calc.UseVisualStyleBackColor = true;
            this.calc.Click += new System.EventHandler(this.calc_Click);
            this.calc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // nextmove
            // 
            this.nextmove.Location = new System.Drawing.Point(699, 631);
            this.nextmove.Name = "nextmove";
            this.nextmove.Size = new System.Drawing.Size(75, 23);
            this.nextmove.TabIndex = 2;
            this.nextmove.Text = "下一步";
            this.nextmove.UseVisualStyleBackColor = true;
            this.nextmove.Click += new System.EventHandler(this.nextmove_Click);
            this.nextmove.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // holdb
            // 
            this.holdb.AutoSize = true;
            this.holdb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.holdb.Location = new System.Drawing.Point(36, 78);
            this.holdb.Name = "holdb";
            this.holdb.Size = new System.Drawing.Size(48, 16);
            this.holdb.TabIndex = 4;
            this.holdb.Text = "hold:";
            this.holdb.Click += new System.EventHandler(this.holdb_Click);
            // 
            // nodes
            // 
            this.nodes.AutoSize = true;
            this.nodes.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nodes.Location = new System.Drawing.Point(569, 603);
            this.nodes.Name = "nodes";
            this.nodes.Size = new System.Drawing.Size(64, 16);
            this.nodes.TabIndex = 4;
            this.nodes.Text = "nodes: ";
            this.nodes.Click += new System.EventHandler(this.holdb_Click);
            // 
            // fielddata
            // 
            this.fielddata.Location = new System.Drawing.Point(248, 713);
            this.fielddata.Name = "fielddata";
            this.fielddata.Size = new System.Drawing.Size(100, 21);
            this.fielddata.TabIndex = 5;
            // 
            // daochu
            // 
            this.daochu.Location = new System.Drawing.Point(355, 710);
            this.daochu.Name = "daochu";
            this.daochu.Size = new System.Drawing.Size(75, 23);
            this.daochu.TabIndex = 6;
            this.daochu.Text = "导出";
            this.daochu.UseVisualStyleBackColor = true;
            this.daochu.Click += new System.EventHandler(this.daochu_Click);
            this.daochu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // daoru
            // 
            this.daoru.Location = new System.Drawing.Point(436, 712);
            this.daoru.Name = "daoru";
            this.daoru.Size = new System.Drawing.Size(75, 23);
            this.daoru.TabIndex = 6;
            this.daoru.Text = "导入";
            this.daoru.UseVisualStyleBackColor = true;
            this.daoru.Click += new System.EventHandler(this.daoru_Click);
            this.daoru.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // Nexttt
            // 
            this.Nexttt.AutoSize = true;
            this.Nexttt.Location = new System.Drawing.Point(355, 684);
            this.Nexttt.Name = "Nexttt";
            this.Nexttt.Size = new System.Drawing.Size(41, 12);
            this.Nexttt.TabIndex = 7;
            this.Nexttt.Text = "Next：";
            // 
            // printall
            // 
            this.printall.Location = new System.Drawing.Point(699, 660);
            this.printall.Name = "printall";
            this.printall.Size = new System.Drawing.Size(75, 23);
            this.printall.TabIndex = 2;
            this.printall.Text = "全部输出";
            this.printall.UseVisualStyleBackColor = true;
            this.printall.Click += new System.EventHandler(this.printall_Click);
            this.printall.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            // 
            // CC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 747);
            this.Controls.Add(this.Nexttt);
            this.Controls.Add(this.daoru);
            this.Controls.Add(this.daochu);
            this.Controls.Add(this.fielddata);
            this.Controls.Add(this.nodes);
            this.Controls.Add(this.holdb);
            this.Controls.Add(this.nextqueue);
            this.Controls.Add(this.printall);
            this.Controls.Add(this.nextmove);
            this.Controls.Add(this.calc);
            this.Controls.Add(this.clearall);
            this.Controls.Add(this.lineclear);
            this.Controls.Add(this.Mode);
            this.Name = "CC";
            this.Text = "Cold Clear";
            this.Load += new System.EventHandler(this.CC_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CC_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CC_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CC_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Mode;
        private System.Windows.Forms.Button lineclear;
        private System.Windows.Forms.Button clearall;
        private System.Windows.Forms.TextBox nextqueue;
        private System.Windows.Forms.Button calc;
        private System.Windows.Forms.Button nextmove;
        private System.Windows.Forms.Label holdb;
        private System.Windows.Forms.Label nodes;
        private System.Windows.Forms.TextBox fielddata;
        private System.Windows.Forms.Button daochu;
        private System.Windows.Forms.Button daoru;
        private System.Windows.Forms.Label Nexttt;
        private System.Windows.Forms.Button printall;
    }
}

