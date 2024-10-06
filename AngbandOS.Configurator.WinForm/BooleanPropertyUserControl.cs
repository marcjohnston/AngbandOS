using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class BooleanPropertyUserControl : UserControl
    {
        public BooleanPropertyUserControl(PropertyMetadata booleanPropertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? booleanPropertyInfo = configuration.GetType().GetProperty(booleanPropertyMetadata.PropertyName);
            if (booleanPropertyInfo == null)
            {
                throw new Exception($"Configuration object doesn't have associated {booleanPropertyMetadata.PropertyName}.");
            }

            if (booleanPropertyInfo.PropertyType != typeof(bool))
            {
                MessageBox.Show($"The boolean property {booleanPropertyMetadata.PropertyName} doesn't reference a bool property in the configuration.");
                return;
            }
            titleLabel.Text = booleanPropertyMetadata.Title ?? booleanPropertyMetadata.PropertyName;
            descriptionLabel.Text = booleanPropertyMetadata.Description;
            object? value = booleanPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case bool boolValue:
                    checkBox1.Checked = boolValue;
                    break;
                default:
                    MessageBox.Show($"The boolean property {booleanPropertyMetadata.PropertyName} did not return a bool value from the configuration.");
                    break;
            }
        }
    }
}
