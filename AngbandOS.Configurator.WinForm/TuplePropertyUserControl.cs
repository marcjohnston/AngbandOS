using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class TuplePropertyUserControl : UserControl, IPropertyUserControl
    {
        public TuplePropertyUserControl(TuplePropertyMetadata tuplePropertyMetadata, IGameConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? tuplePropertyInfo = configuration.GetType().GetProperty(tuplePropertyMetadata.PropertyName);
            if (tuplePropertyInfo == null)
            {
                MessageBox.Show($"Configuration object doesn't have associated {tuplePropertyMetadata.PropertyName}.");
                return;
            }

            titleLabel.Text = tuplePropertyMetadata.Title ?? tuplePropertyMetadata.PropertyName;
            descriptionLabel.Text = tuplePropertyMetadata.Description;

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnCount = tuplePropertyMetadata.Types.Length;
            tableLayoutPanel1.RowCount = 1;
            int columnIndex = 0;
            foreach (PropertyMetadata typePropertyMetadata in tuplePropertyMetadata.Types)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / tuplePropertyMetadata.Types.Length));
                Label rowHeaderLabel = new Label()
                {
                    Text = typePropertyMetadata.PropertyName,
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };
                tableLayoutPanel1.Controls.Add(rowHeaderLabel, columnIndex, 0);
                columnIndex++;
            }
            //var propertyType = tuplePropertyInfo.PropertyType;
            //if (propertyType.IsGenericType)
            //{
            //    // Get the generic type definition
            //    var genericTypeDefinition = propertyType.GetGenericTypeDefinition();

            //    // Check if it's assignable from Tuple<> or ValueTuple<>
            //    bool isTuple = typeof(Tuple).IsAssignableFrom(genericTypeDefinition) || typeof(ValueTuple).IsAssignableFrom(genericTypeDefinition);
            //}

            //if (tuplePropertyInfo.PropertyType != typeof(string))
            //{
            //    MessageBox.Show($"The string property {propertyMetadata.PropertyName} doesn't reference a string property in the configuration.");
            //    return;
            //}
            //object? value = tuplePropertyInfo.GetValue(configuration);

            //switch (value)
            //{
            //    case null:
            //        break;
            //    case string stringValue:
            //        textBox1.Text = stringValue.ToString();
            //        break;
            //    default:
            //        MessageBox.Show($"The string property {propertyMetadata.PropertyName} did not return a string value from the configuration.");
            //        break;
            //}
        }
    }
}
