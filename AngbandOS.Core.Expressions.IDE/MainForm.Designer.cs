namespace AngbandOS.Core.Expressions.IDE
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            treeView1 = new TreeView();
            computeButton = new Button();
            computeLabel = new Label();
            statusLabel = new Label();
            label1 = new Label();
            experienceValueTextBox = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(12, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(641, 23);
            textBox1.TabIndex = 0;
            textBox1.Text = "-(10+x)+5d6*x/2+30";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(14, 69);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Parse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // treeView1
            // 
            treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            treeView1.Location = new Point(15, 125);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(773, 256);
            treeView1.TabIndex = 2;
            // 
            // computeButton
            // 
            computeButton.Location = new Point(15, 387);
            computeButton.Name = "computeButton";
            computeButton.Size = new Size(75, 23);
            computeButton.TabIndex = 3;
            computeButton.Text = "Compute";
            computeButton.UseVisualStyleBackColor = true;
            computeButton.Click += computeButton_Click;
            // 
            // computeLabel
            // 
            computeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            computeLabel.Location = new Point(17, 421);
            computeLabel.Name = "computeLabel";
            computeLabel.Size = new Size(771, 20);
            computeLabel.TabIndex = 4;
            // 
            // statusLabel
            // 
            statusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusLabel.Location = new Point(15, 99);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(773, 23);
            statusLabel.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(672, 10);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 6;
            label1.Text = "Experience Value:";
            // 
            // experienceValueTextBox
            // 
            experienceValueTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            experienceValueTextBox.Location = new Point(672, 28);
            experienceValueTextBox.Name = "experienceValueTextBox";
            experienceValueTextBox.Size = new Size(116, 23);
            experienceValueTextBox.TabIndex = 7;
            experienceValueTextBox.Text = "8";
            // 
            // MainForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(experienceValueTextBox);
            Controls.Add(label1);
            Controls.Add(statusLabel);
            Controls.Add(computeLabel);
            Controls.Add(computeButton);
            Controls.Add(treeView1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "MainForm";
            Text = "AngbandOS Expression IDE";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private TreeView treeView1;
        private Button computeButton;
        private Label computeLabel;
        private Label statusLabel;
        private Label label1;
        private TextBox experienceValueTextBox;
    }
}
