using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class StringPropertyUserControl : UserControl, IPropertyUserControl
    {
        public StringPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo stringPropertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
            if (stringPropertyInfo == null)
            {
                throw new Exception($"Configuration object doesn't have associated {propertyMetadata.PropertyName}.");
            }

            label1.Text = propertyMetadata.Title ?? propertyMetadata.PropertyName;
            textBox1.Text = (string)stringPropertyInfo.GetValue(configuration);
        }
    }
}
