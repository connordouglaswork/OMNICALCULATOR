namespace OMNIATHLETICS
{
    partial class FormProjectionVelocity
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelVel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxVelocity = new System.Windows.Forms.TextBox();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.buttonRefresh);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelVel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.buttonAbout);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonCalculate);
            this.panel1.Controls.Add(this.textBoxVelocity);
            this.panel1.Controls.Add(this.textBoxAngle);
            this.panel1.Location = new System.Drawing.Point(307, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 548);
            this.panel1.TabIndex = 12;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.Color.White;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefresh.Location = new System.Drawing.Point(141, 491);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(66, 31);
            this.buttonRefresh.TabIndex = 25;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = false;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::OMNIATHLETICS.Properties.Resources.biomechanicsimage;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(132, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 93);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // labelVel
            // 
            this.labelVel.AutoSize = true;
            this.labelVel.Font = new System.Drawing.Font("Arial", 16F);
            this.labelVel.ForeColor = System.Drawing.SystemColors.Control;
            this.labelVel.Location = new System.Drawing.Point(52, 311);
            this.labelVel.Name = "labelVel";
            this.labelVel.Size = new System.Drawing.Size(100, 25);
            this.labelVel.TabIndex = 21;
            this.labelVel.Text = "Velocity: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(47, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Projetion Angle (Deg):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(47, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Projection Velocity (ms-1):";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(50, 281);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 1);
            this.panel3.TabIndex = 17;
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAbout.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAbout.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonAbout.Location = new System.Drawing.Point(50, 414);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(255, 39);
            this.buttonAbout.TabIndex = 2;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = false;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(50, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(255, 1);
            this.panel2.TabIndex = 16;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(50, 491);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(66, 31);
            this.buttonBack.TabIndex = 15;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 70);
            this.label1.TabIndex = 13;
            this.label1.Text = "Horizontal Projection \r\n             Velocity";
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Location = new System.Drawing.Point(239, 491);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(66, 31);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.White;
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.Location = new System.Drawing.Point(50, 360);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(255, 39);
            this.buttonCalculate.TabIndex = 3;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // textBoxVelocity
            // 
            this.textBoxVelocity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.textBoxVelocity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxVelocity.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVelocity.ForeColor = System.Drawing.SystemColors.Control;
            this.textBoxVelocity.Location = new System.Drawing.Point(213, 219);
            this.textBoxVelocity.Name = "textBoxVelocity";
            this.textBoxVelocity.Size = new System.Drawing.Size(92, 15);
            this.textBoxVelocity.TabIndex = 4;
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(29)))));
            this.textBoxAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAngle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAngle.ForeColor = System.Drawing.SystemColors.Control;
            this.textBoxAngle.Location = new System.Drawing.Point(186, 260);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(119, 15);
            this.textBoxAngle.TabIndex = 5;
            // 
            // FormProjectionVelocity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::OMNIATHLETICS.Properties.Resources.homepagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(970, 699);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProjectionVelocity";
            this.Text = "FormProjectionVelocity";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelVel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxVelocity;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRefresh;
    }
}