namespace BrickBreaker
{
    partial class HighScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.highScores = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // highScores
            // 
            this.highScores.AutoSize = true;
            this.highScores.BackColor = System.Drawing.Color.Transparent;
            this.highScores.Font = new System.Drawing.Font("OCR A Std", 14F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScores.ForeColor = System.Drawing.Color.Cyan;
            this.highScores.Location = new System.Drawing.Point(50, 111);
            this.highScores.Name = "highScores";
            this.highScores.Size = new System.Drawing.Size(51, 380);
            this.highScores.TabIndex = 5;
            this.highScores.Text = "1.\r\n\r\n2.\r\n\r\n3.\r\n\r\n4.\r\n\r\n5.\r\n\r\n6.\r\n\r\n7.\r\n\r\n8.\r\n\r\n9.\r\n\r\n10.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Std", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(50, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "High Scores";
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.Transparent;
            this.menuButton.BackgroundImage = global::BrickBreaker.Properties.Resources.button;
            this.menuButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.menuButton.FlatAppearance.BorderSize = 0;
            this.menuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.menuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("OCR A Std", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.ForeColor = System.Drawing.Color.Cyan;
            this.menuButton.Location = new System.Drawing.Point(310, 236);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(181, 78);
            this.menuButton.TabIndex = 7;
            this.menuButton.Text = "Main Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // HighScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::BrickBreaker.Properties.Resources.Stars;
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.highScores);
            this.Name = "HighScreen";
            this.Size = new System.Drawing.Size(800, 550);
            this.Load += new System.EventHandler(this.HighScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();


        }

        #endregion
		private System.Windows.Forms.Label highScores;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button menuButton;
    }

}

