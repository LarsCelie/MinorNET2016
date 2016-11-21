namespace Minor.Dag41.AwesomeAsyncApplication
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
            this.txtInput1 = new System.Windows.Forms.TextBox();
            this.txtInput2 = new System.Windows.Forms.TextBox();
            this.txtInput3 = new System.Windows.Forms.TextBox();
            this.btnSumOfSquares = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput1
            // 
            this.txtInput1.Location = new System.Drawing.Point(13, 13);
            this.txtInput1.Name = "txtInput1";
            this.txtInput1.Size = new System.Drawing.Size(100, 20);
            this.txtInput1.TabIndex = 0;
            this.txtInput1.Text = "2";
            this.txtInput1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInput2
            // 
            this.txtInput2.Location = new System.Drawing.Point(13, 40);
            this.txtInput2.Name = "txtInput2";
            this.txtInput2.Size = new System.Drawing.Size(100, 20);
            this.txtInput2.TabIndex = 1;
            this.txtInput2.Text = "3";
            this.txtInput2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInput3
            // 
            this.txtInput3.Location = new System.Drawing.Point(13, 67);
            this.txtInput3.Name = "txtInput3";
            this.txtInput3.Size = new System.Drawing.Size(100, 20);
            this.txtInput3.TabIndex = 2;
            this.txtInput3.Text = "4";
            this.txtInput3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSumOfSquares
            // 
            this.btnSumOfSquares.Location = new System.Drawing.Point(13, 94);
            this.btnSumOfSquares.Name = "btnSumOfSquares";
            this.btnSumOfSquares.Size = new System.Drawing.Size(100, 71);
            this.btnSumOfSquares.TabIndex = 3;
            this.btnSumOfSquares.Text = "Sum of squares";
            this.btnSumOfSquares.UseVisualStyleBackColor = true;
            this.btnSumOfSquares.Click += new System.EventHandler(this.btnSumOfSquares_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(13, 172);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(100, 20);
            this.txtOutput.TabIndex = 4;
            this.txtOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(126, 206);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSumOfSquares);
            this.Controls.Add(this.txtInput3);
            this.Controls.Add(this.txtInput2);
            this.Controls.Add(this.txtInput1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput1;
        private System.Windows.Forms.TextBox txtInput2;
        private System.Windows.Forms.TextBox txtInput3;
        private System.Windows.Forms.Button btnSumOfSquares;
        private System.Windows.Forms.TextBox txtOutput;
    }
}

