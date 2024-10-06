using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class BooleanPropertyUserControl : UserControl
    {
        public BooleanPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo? booleanPropertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
            if (booleanPropertyInfo == null)
            {
                throw new Exception($"Configuration object doesn't have associated {propertyMetadata.PropertyName}.");
            }

            if (booleanPropertyInfo.PropertyType != typeof(bool))
            {
                MessageBox.Show($"The boolean property {propertyMetadata.PropertyName} doesn't reference a bool property in the configuration.");
                return;
            }
            titleLabel.Text = propertyMetadata.Title ?? propertyMetadata.PropertyName;
            descriptionLabel.Text = propertyMetadata.Description;
            object? value = booleanPropertyInfo.GetValue(configuration);

            switch (value)
            {
                case null:
                    break;
                case bool boolValue:
                    checkBox1.Checked = boolValue;
                    break;
                default:
                    MessageBox.Show($"The boolean property {propertyMetadata.PropertyName} did not return a bool value from the configuration.");
                    break;
            }
        }
    }
}
