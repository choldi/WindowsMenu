namespace WindowsMenu
{
    partial class frmPrograma
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.btnPrograma = new System.Windows.Forms.Button();
            this.btnIcono = new System.Windows.Forms.Button();
            this.txtIcono = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.btnPre = new System.Windows.Forms.Button();
            this.txtPre = new System.Windows.Forms.TextBox();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.ofd1 = new System.Windows.Forms.OpenFileDialog();
            this.cbDefault = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Programa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Icono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Etiqueta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "PreExec";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "PostExec";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Posicion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(234, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ejecutar pre y postExec defecto";
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(149, 19);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(424, 26);
            this.txtPrograma.TabIndex = 7;
            // 
            // btnPrograma
            // 
            this.btnPrograma.Location = new System.Drawing.Point(588, 21);
            this.btnPrograma.Name = "btnPrograma";
            this.btnPrograma.Size = new System.Drawing.Size(39, 24);
            this.btnPrograma.TabIndex = 8;
            this.btnPrograma.Text = "...";
            this.btnPrograma.UseVisualStyleBackColor = true;
            this.btnPrograma.Click += new System.EventHandler(this.btnPrograma_Click);
            // 
            // btnIcono
            // 
            this.btnIcono.Location = new System.Drawing.Point(588, 71);
            this.btnIcono.Name = "btnIcono";
            this.btnIcono.Size = new System.Drawing.Size(39, 24);
            this.btnIcono.TabIndex = 10;
            this.btnIcono.Text = "...";
            this.btnIcono.UseVisualStyleBackColor = true;
            this.btnIcono.Click += new System.EventHandler(this.btnIcono_Click);
            // 
            // txtIcono
            // 
            this.txtIcono.Location = new System.Drawing.Point(149, 69);
            this.txtIcono.Name = "txtIcono";
            this.txtIcono.Size = new System.Drawing.Size(424, 26);
            this.txtIcono.TabIndex = 9;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(149, 119);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(424, 26);
            this.txtLabel.TabIndex = 11;
            // 
            // btnPre
            // 
            this.btnPre.Location = new System.Drawing.Point(588, 171);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(39, 24);
            this.btnPre.TabIndex = 14;
            this.btnPre.Text = "...";
            this.btnPre.UseVisualStyleBackColor = true;
            this.btnPre.Click += new System.EventHandler(this.btnPre_Click);
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(149, 169);
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(424, 26);
            this.txtPre.TabIndex = 13;
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(588, 221);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(39, 24);
            this.btnPost.TabIndex = 16;
            this.btnPost.Text = "...";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(149, 219);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(424, 26);
            this.txtPost.TabIndex = 15;
            // 
            // cbDefault
            // 
            this.cbDefault.AutoSize = true;
            this.cbDefault.Location = new System.Drawing.Point(277, 329);
            this.cbDefault.Name = "cbDefault";
            this.cbDefault.Size = new System.Drawing.Size(15, 14);
            this.cbDefault.TabIndex = 17;
            this.cbDefault.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(184, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 18;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(438, 381);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(145, 275);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(51, 20);
            this.lblPosition.TabIndex = 20;
            this.lblPosition.Text = "label8";
            // 
            // frmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 457);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbDefault);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.btnPre);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.btnIcono);
            this.Controls.Add(this.txtIcono);
            this.Controls.Add(this.btnPrograma);
            this.Controls.Add(this.txtPrograma);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmPrograma";
            this.Text = "frmPrograma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.Button btnPrograma;
        private System.Windows.Forms.Button btnIcono;
        private System.Windows.Forms.TextBox txtIcono;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button btnPre;
        private System.Windows.Forms.TextBox txtPre;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.OpenFileDialog ofd1;
        private System.Windows.Forms.CheckBox cbDefault;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPosition;
    }
}