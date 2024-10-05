namespace AngbandOS.Configurator.WinForm
{
    partial class StringPropertyUserControl
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
            label1 = new Label();
            textBox1 = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(47, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(254, 23);
            textBox1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(438, 47);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // StringPropertyUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "StringPropertyUserControl";
            Size = new Size(438, 47);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
