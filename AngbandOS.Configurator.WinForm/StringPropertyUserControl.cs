using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class StringPropertyUserControl : UserControl, IPropertyUserControl
    {
        public StringPropertyUserControl(PropertyMetadata stringPropertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? stringPropertyInfo = configuration.GetType().GetProperty(stringPropertyMetadata.PropertyName);
            if (stringPropertyInfo == null)
            {
                MessageBox.Show($"Configuration object doesn't have associated {stringPropertyMetadata.PropertyName}.");
                return;
            }

            if (stringPropertyInfo.PropertyType != typeof(string))
            {
                MessageBox.Show($"The string property {stringPropertyMetadata.PropertyName} doesn't reference a string property in the configuration.");
                return;
            }
            titleLabel.Text = stringPropertyMetadata.Title ?? stringPropertyMetadata.PropertyName;
            descriptionLabel.Text = stringPropertyMetadata.Description;
            object? value = stringPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case string stringValue:
                    textBox1.Text = stringValue.ToString();
                    break;
                default:
                    MessageBox.Show($"The string property {stringPropertyMetadata.PropertyName} did not return a string value from the configuration.");
                    break;
            }
        }
    }
}
