namespace Assignment_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mapLabel1 = new System.Windows.Forms.Label();
            this.mapLabel2 = new System.Windows.Forms.Label();
            this.txtBxMapX = new System.Windows.Forms.TextBox();
            this.txtBxMapY = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(26, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(275, 342);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(378, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Rounds Complete";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(390, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 164);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(589, 254);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 164);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(589, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(160, 164);
            this.button3.TabIndex = 4;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(19, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 389);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(381, 164);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 39);
            this.button4.TabIndex = 6;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(469, 164);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 39);
            this.button5.TabIndex = 7;
            this.button5.Text = "Read";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // mapLabel1
            // 
            this.mapLabel1.AutoSize = true;
            this.mapLabel1.Location = new System.Drawing.Point(378, 40);
            this.mapLabel1.Name = "mapLabel1";
            this.mapLabel1.Size = new System.Drawing.Size(99, 13);
            this.mapLabel1.TabIndex = 8;
            this.mapLabel1.Text = "X-Axis Map Bounds";
            this.mapLabel1.Click += new System.EventHandler(this.label2_Click);
            // 
            // mapLabel2
            // 
            this.mapLabel2.AutoSize = true;
            this.mapLabel2.Location = new System.Drawing.Point(378, 68);
            this.mapLabel2.Name = "mapLabel2";
            this.mapLabel2.Size = new System.Drawing.Size(99, 13);
            this.mapLabel2.TabIndex = 9;
            this.mapLabel2.Text = "Y-Axis Map Bounds";
            // 
            // txtBxMapX
            // 
            this.txtBxMapX.Location = new System.Drawing.Point(483, 37);
            this.txtBxMapX.Name = "txtBxMapX";
            this.txtBxMapX.Size = new System.Drawing.Size(67, 20);
            this.txtBxMapX.TabIndex = 10;
            // 
            // txtBxMapY
            // 
            this.txtBxMapY.Location = new System.Drawing.Point(483, 65);
            this.txtBxMapY.Name = "txtBxMapY";
            this.txtBxMapY.Size = new System.Drawing.Size(67, 20);
            this.txtBxMapY.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBxMapY);
            this.Controls.Add(this.txtBxMapX);
            this.Controls.Add(this.mapLabel2);
            this.Controls.Add(this.mapLabel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "RTS Game";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label mapLabel1;
        private System.Windows.Forms.Label mapLabel2;
        public System.Windows.Forms.TextBox txtBxMapX;
        public System.Windows.Forms.TextBox txtBxMapY;
    }
}

