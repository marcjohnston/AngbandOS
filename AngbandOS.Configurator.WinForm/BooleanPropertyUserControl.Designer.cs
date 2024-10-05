namespace AngbandOS.Configurator.WinForm
{
    partial class BooleanPropertyUserControl
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
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.Dock = DockStyle.Fill;
            checkBox1.Location = new Point(0, 0);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(666, 26);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "checkBox1";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // BooleanPropertyUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(checkBox1);
            Name = "BooleanPropertyUserControl";
            Size = new Size(666, 26);
            ResumeLayout(false);
        }

        #endregion

        private CheckBox checkBox1;
    }
}
