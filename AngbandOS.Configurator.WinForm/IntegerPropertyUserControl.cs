using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class IntegerPropertyUserControl : UserControl, IPropertyUserControl
    {
        public IntegerPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? integerPropertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
            if (integerPropertyInfo == null)
            {
                MessageBox.Show($"Configuration object doesn't have associated {propertyMetadata.PropertyName}.");
                return;
            }

            if (integerPropertyInfo.PropertyType != typeof(int) && integerPropertyInfo.PropertyType != typeof(int?))
            {
                MessageBox.Show($"The integer property {propertyMetadata.PropertyName} doesn't reference an int property in the configuration.");
                return;
            }
            titleLabel.Text = propertyMetadata.Title ?? propertyMetadata.PropertyName;
            descriptionLabel.Text = propertyMetadata.Description;
            object? value = integerPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case int intValue:
                    textBox1.Text = intValue.ToString();
                    break;
                default:
                    MessageBox.Show($"The integer property {propertyMetadata.PropertyName} did not return an int value from the configuration.");
                    break;
            }
        }
    }
}
