using AngbandOS.Core.Interface;

namespace AngbandOS.Configurator.WinForm
{
    public partial class BooleanPropertyUserControl : UserControl, IPropertyUserControl
    {
        public BooleanPropertyUserControl(PropertyMetadata propertyMetadata, IConfiguration configuration)
        {
            InitializeComponent();
            checkBox1.Text = propertyMetadata.Title;
        }
    }
}
