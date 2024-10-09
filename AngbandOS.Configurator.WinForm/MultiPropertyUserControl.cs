using AngbandOS.Core.Interface;
using System.Reflection;
using System.Windows.Forms;

namespace AngbandOS.Configurator.WinForm
{
    public partial class MultiPropertyUserControl : UserControl
    {
        public MultiPropertyUserControl(PropertyMetadata[] propertiesMetadata, IGameConfiguration configuration, string breadcrumb)
        {
            InitializeComponent();

            tableLayoutPanel1.SuspendLayout();

            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.RowStyles.Clear();

            // Enumerate the metadata properties.
            foreach (PropertyMetadata propertyMetadata in propertiesMetadata)
            {
                PropertyInfo? propertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
                if (propertyInfo == null)
                {
                    MessageBox.Show($"The {breadcrumb}/{propertyMetadata.PropertyName} metadata references a configuration property that is not valid.");
                    return;
                }

                UserControl propertyUserControl;
                switch (propertyMetadata)
                {
                    case CollectionPropertyMetadata collectionPropertyMetadata:
                        propertyUserControl = new CollectionPropertyUserControl(collectionPropertyMetadata, configuration, "configuration");
                        break;
                    case BooleanPropertyMetadata booleanPropertyMetadata:
                        propertyUserControl = new BooleanPropertyUserControl(booleanPropertyMetadata, configuration);
                        break;
                    case StringPropertyMetadata stringPropertyMetadata:
                        propertyUserControl = new StringPropertyUserControl(stringPropertyMetadata, configuration);
                        break;
                    case IntegerPropertyMetadata integerPropertyMetadata:
                        propertyUserControl = new IntegerPropertyUserControl(integerPropertyMetadata, configuration);
                        break;
                    case TuplePropertyMetadata tuplePropertyMetadata:
                        propertyUserControl = new TuplePropertyUserControl(tuplePropertyMetadata, configuration);
                        break;
                    default:
                        MessageBox.Show($"An error occurred while processing the metadata property {breadcrumb}/{propertyMetadata.PropertyName}.  The metadata property type {propertyMetadata.GetType().Name} is not supported.");
                        return;
                }
                tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                propertyUserControl.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(propertyUserControl, 0, tableLayoutPanel1.RowCount);
            }

            tableLayoutPanel1.ResumeLayout();
        }
    }
}
