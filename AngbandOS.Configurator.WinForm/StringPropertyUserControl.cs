using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class StringPropertyUserControl : UserControl, IPropertyUserControl
    {
        public StringPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? stringPropertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
            if (stringPropertyInfo == null)
            {
                MessageBox.Show($"Configuration object doesn't have associated {propertyMetadata.PropertyName}.");
                return;
            }

            if (stringPropertyInfo.PropertyType != typeof(string))
            {
                MessageBox.Show($"The string property {propertyMetadata.PropertyName} doesn't reference a string property in the configuration.");
                return;
            }
            titleLabel.Text = propertyMetadata.Title ?? propertyMetadata.PropertyName;
            descriptionLabel.Text = propertyMetadata.Description;
            object? value = stringPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case string stringValue:
                    textBox1.Text = stringValue.ToString();
                    break;
                default:
                    MessageBox.Show($"The string property {propertyMetadata.PropertyName} did not return a string value from the configuration.");
                    break;
            }
        }
    }
}
