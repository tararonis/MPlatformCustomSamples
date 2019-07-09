namespace MP_GPU_CGissue
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
            this.panelPrev = new System.Windows.Forms.Panel();
            this.Repr_bug = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelPrev
            // 
            this.panelPrev.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelPrev.Location = new System.Drawing.Point(51, 28);
            this.panelPrev.Name = "panelPrev";
            this.panelPrev.Size = new System.Drawing.Size(800, 800);
            this.panelPrev.TabIndex = 1;
            // 
            // Repr_bug
            // 
            this.Repr_bug.Location = new System.Drawing.Point(879, 28);
            this.Repr_bug.Name = "Repr_bug";
            this.Repr_bug.Size = new System.Drawing.Size(75, 800);
            this.Repr_bug.TabIndex = 2;
            this.Repr_bug.Text = "Reproduce";
            this.Repr_bug.UseVisualStyleBackColor = true;
            this.Repr_bug.Click += new System.EventHandler(this.Repr_bug_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 855);
            this.Controls.Add(this.Repr_bug);
            this.Controls.Add(this.panelPrev);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrev;
        private System.Windows.Forms.Button Repr_bug;
    }
}

