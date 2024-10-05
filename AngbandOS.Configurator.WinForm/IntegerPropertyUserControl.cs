using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class IntegerPropertyUserControl : UserControl, IPropertyUserControl
    {
        public IntegerPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();

            PropertyInfo integerPropertyInfo = configuration.GetType().GetProperty(propertyMetadata.PropertyName);
            if (integerPropertyInfo == null)
            {
                throw new Exception($"Configuration object doesn't have associated {propertyMetadata.PropertyName}.");
            }

            label1.Text = propertyMetadata.Title;
            textBox1.Text = integerPropertyInfo.GetValue(configuration).ToString();
        }
    }
}
