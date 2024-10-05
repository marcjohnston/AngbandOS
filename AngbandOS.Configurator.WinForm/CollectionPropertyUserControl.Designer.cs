namespace AngbandOS.Configurator.WinForm
{
    partial class CollectionPropertyUserControl
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            titleLabel = new Label();
            descriptionLabel = new Label();
            splitContainer1 = new SplitContainer();
            collectionEntitiesListBox = new ListBox();
            entityFlowLayoutPanel = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainer1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(551, 513);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(titleLabel);
            flowLayoutPanel1.Controls.Add(descriptionLabel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(545, 45);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(3, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(56, 30);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Title";
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(3, 30);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(67, 15);
            descriptionLabel.TabIndex = 1;
            descriptionLabel.Text = "Description";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 54);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(collectionEntitiesListBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.AutoScroll = true;
            splitContainer1.Panel2.Controls.Add(entityFlowLayoutPanel);
            splitContainer1.Size = new Size(545, 456);
            splitContainer1.SplitterDistance = 181;
            splitContainer1.TabIndex = 1;
            // 
            // collectionEntitiesListBox
            // 
            collectionEntitiesListBox.Dock = DockStyle.Fill;
            collectionEntitiesListBox.FormattingEnabled = true;
            collectionEntitiesListBox.ItemHeight = 15;
            collectionEntitiesListBox.Location = new Point(0, 0);
            collectionEntitiesListBox.Name = "collectionEntitiesListBox";
            collectionEntitiesListBox.Size = new Size(181, 456);
            collectionEntitiesListBox.TabIndex = 0;
            collectionEntitiesListBox.SelectedValueChanged += collectionEntitiesListBox_SelectedValueChanged;
            // 
            // entityFlowLayoutPanel
            // 
            entityFlowLayoutPanel.Dock = DockStyle.Fill;
            entityFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            entityFlowLayoutPanel.Location = new Point(0, 0);
            entityFlowLayoutPanel.Name = "entityFlowLayoutPanel";
            entityFlowLayoutPanel.Size = new Size(360, 456);
            entityFlowLayoutPanel.TabIndex = 0;
            entityFlowLayoutPanel.WrapContents = false;
            // 
            // CollectionPropertyUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(tableLayoutPanel1);
            Name = "CollectionPropertyUserControl";
            Size = new Size(551, 513);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label titleLabel;
        private Label descriptionLabel;
        private SplitContainer splitContainer1;
        private ListBox collectionEntitiesListBox;
        private FlowLayoutPanel entityFlowLayoutPanel;
    }
}
