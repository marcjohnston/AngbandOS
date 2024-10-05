namespace AngbandOS.Configurator.WinForm
{
    partial class IntegerPropertyUserControl
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
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(120, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(212, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Location = new Point(1, 6);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 2;
            label1.Text = "label1";
            // 
            // IntegerUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "IntegerUserControl";
            Size = new Size(335, 30);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
    }
}
