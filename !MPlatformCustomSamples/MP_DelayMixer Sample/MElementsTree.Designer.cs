namespace MixerSample
{
    partial class MElementsTree
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
            this.SuspendLayout();
            // 
            // MElementsTree
            // 
            this.CheckBoxes = true;
            this.HideSelection = false;
            this.LineColor = System.Drawing.Color.Black;
            this.Size = new System.Drawing.Size(411, 314);
            this.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.MElementsTree_AfterCheck);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MElementsTree_MouseDoubleClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}