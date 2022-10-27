using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Big6Search.ScriptingEngine
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class AddInManager : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            InstalledAddInsDataGridView = new DataGridView();
            TitleColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)InstalledAddInsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // InstalledAddInsDataGridView
            // 
            InstalledAddInsDataGridView.AllowUserToAddRows = false;
            InstalledAddInsDataGridView.AllowUserToDeleteRows = false;
            InstalledAddInsDataGridView.AllowUserToResizeRows = false;
            InstalledAddInsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InstalledAddInsDataGridView.Columns.AddRange(new DataGridViewColumn[] { TitleColumn, DescriptionColumn });
            InstalledAddInsDataGridView.Dock = DockStyle.Fill;
            InstalledAddInsDataGridView.Location = new Point(0, 0);
            InstalledAddInsDataGridView.Name = "InstalledAddInsDataGridView";
            InstalledAddInsDataGridView.RowHeadersVisible = false;
            InstalledAddInsDataGridView.Size = new Size(579, 262);
            InstalledAddInsDataGridView.TabIndex = 0;
            // 
            // TitleColumn
            // 
            TitleColumn.DataPropertyName = "Title";
            TitleColumn.HeaderText = "Title";
            TitleColumn.Name = "TitleColumn";
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescriptionColumn.DataPropertyName = "Description";
            DescriptionColumn.HeaderText = "Description";
            DescriptionColumn.Name = "DescriptionColumn";
            // 
            // AddInManager
            // 
            AutoScaleDimensions = new SizeF(6.0f, 13.0f);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 262);
            Controls.Add(InstalledAddInsDataGridView);
            Name = "AddInManager";
            Text = "Add-in Manager";
            ((System.ComponentModel.ISupportInitialize)InstalledAddInsDataGridView).EndInit();
            ResumeLayout(false);

        }
        internal DataGridView InstalledAddInsDataGridView;
        internal DataGridViewTextBoxColumn TitleColumn;
        internal DataGridViewTextBoxColumn DescriptionColumn;
    }
}