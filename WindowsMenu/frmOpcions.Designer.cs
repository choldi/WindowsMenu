namespace WindowsMenu
{
    partial class frmOpcions
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
            this.txtPre = new System.Windows.Forms.TextBox();
            this.opfExec = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenPre = new System.Windows.Forms.Button();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.btnOpenPost = new System.Windows.Forms.Button();
            this.cbExit = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblRowVal = new System.Windows.Forms.Label();
            this.lblColVal = new System.Windows.Forms.Label();
            this.tbRows = new System.Windows.Forms.TrackBar();
            this.tbColumns = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tbRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PreExec";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "PostExec";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Filas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Columnas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Salir al ejecutar";
            // 
            // txtPre
            // 
            this.txtPre.Location = new System.Drawing.Point(117, 24);
            this.txtPre.Name = "txtPre";
            this.txtPre.Size = new System.Drawing.Size(342, 26);
            this.txtPre.TabIndex = 5;
            // 
            // opfExec
            // 
            this.opfExec.Filter = "Exec|*.exe;*.bat;*.cmd|All files|*.*";
            // 
            // btnOpenPre
            // 
            this.btnOpenPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPre.Location = new System.Drawing.Point(465, 21);
            this.btnOpenPre.Name = "btnOpenPre";
            this.btnOpenPre.Size = new System.Drawing.Size(26, 29);
            this.btnOpenPre.TabIndex = 6;
            this.btnOpenPre.Text = "...";
            this.btnOpenPre.UseVisualStyleBackColor = true;
            this.btnOpenPre.Click += new System.EventHandler(this.btnOpenPre_Click);
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(117, 74);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(342, 26);
            this.txtPost.TabIndex = 7;
            // 
            // btnOpenPost
            // 
            this.btnOpenPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenPost.Location = new System.Drawing.Point(465, 71);
            this.btnOpenPost.Name = "btnOpenPost";
            this.btnOpenPost.Size = new System.Drawing.Size(26, 29);
            this.btnOpenPost.TabIndex = 8;
            this.btnOpenPost.Text = "...";
            this.btnOpenPost.UseVisualStyleBackColor = true;
            this.btnOpenPost.Click += new System.EventHandler(this.btnOpenPost_Click);
            // 
            // cbExit
            // 
            this.cbExit.AutoSize = true;
            this.cbExit.Location = new System.Drawing.Point(163, 234);
            this.cbExit.Name = "cbExit";
            this.cbExit.Size = new System.Drawing.Size(15, 14);
            this.cbExit.TabIndex = 11;
            this.cbExit.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(163, 274);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 31);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(272, 274);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 31);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblRowVal
            // 
            this.lblRowVal.AutoSize = true;
            this.lblRowVal.Location = new System.Drawing.Point(465, 130);
            this.lblRowVal.Name = "lblRowVal";
            this.lblRowVal.Size = new System.Drawing.Size(0, 20);
            this.lblRowVal.TabIndex = 14;
            // 
            // lblColVal
            // 
            this.lblColVal.AutoSize = true;
            this.lblColVal.Location = new System.Drawing.Point(465, 183);
            this.lblColVal.Name = "lblColVal";
            this.lblColVal.Size = new System.Drawing.Size(0, 20);
            this.lblColVal.TabIndex = 15;
            // 
            // tbRows
            // 
            this.tbRows.Location = new System.Drawing.Point(117, 130);
            this.tbRows.Maximum = 20;
            this.tbRows.Minimum = 2;
            this.tbRows.Name = "tbRows";
            this.tbRows.Size = new System.Drawing.Size(342, 45);
            this.tbRows.TabIndex = 9;
            this.tbRows.Value = 2;
            this.tbRows.Scroll += new System.EventHandler(this.tbRows_Scroll);
            // 
            // tbColumns
            // 
            this.tbColumns.Location = new System.Drawing.Point(116, 180);
            this.tbColumns.Maximum = 20;
            this.tbColumns.Minimum = 2;
            this.tbColumns.Name = "tbColumns";
            this.tbColumns.Size = new System.Drawing.Size(342, 45);
            this.tbColumns.TabIndex = 10;
            this.tbColumns.Value = 2;
            this.tbColumns.Scroll += new System.EventHandler(this.tbColumns_Scroll);
            // 
            // frmOpcions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 332);
            this.Controls.Add(this.tbColumns);
            this.Controls.Add(this.tbRows);
            this.Controls.Add(this.lblColVal);
            this.Controls.Add(this.lblRowVal);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbExit);
            this.Controls.Add(this.btnOpenPost);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.btnOpenPre);
            this.Controls.Add(this.txtPre);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmOpcions";
            this.Text = "frmOpcions";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPre;
        private System.Windows.Forms.OpenFileDialog opfExec;
        private System.Windows.Forms.Button btnOpenPre;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.Button btnOpenPost;
        private System.Windows.Forms.CheckBox cbExit;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRowVal;
        private System.Windows.Forms.Label lblColVal;
        private System.Windows.Forms.TrackBar tbRows;
        private System.Windows.Forms.TrackBar tbColumns;
    }
}