using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class IntegerPropertyUserControl : UserControl, IPropertyUserControl
    {
        public IntegerPropertyUserControl(PropertyMetadata integerPropertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? integerPropertyInfo = configuration.GetType().GetProperty(integerPropertyMetadata.PropertyName);
            if (integerPropertyInfo == null)
            {
                MessageBox.Show($"Configuration object doesn't have associated {integerPropertyMetadata.PropertyName}.");
                return;
            }

            if (integerPropertyInfo.PropertyType != typeof(int) && integerPropertyInfo.PropertyType != typeof(int?))
            {
                MessageBox.Show($"The integer property {integerPropertyMetadata.PropertyName} doesn't reference an int property in the configuration.");
                return;
            }
            titleLabel.Text = integerPropertyMetadata.Title ?? integerPropertyMetadata.PropertyName;
            descriptionLabel.Text = integerPropertyMetadata.Description;
            object? value = integerPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case int intValue:
                    textBox1.Text = intValue.ToString();
                    break;
                default:
                    MessageBox.Show($"The integer property {integerPropertyMetadata.PropertyName} did not return an int value from the configuration.");
                    break;
            }
        }
    }
}
