
namespace Big6Search.ScriptingEngine
{
    public partial class AddInManager
    {
        public AddInManager(ScriptEngine scriptEngine)
        {
            InitializeComponent();
            InstalledAddInsDataGridView.DataSource = scriptEngine.InstalledAddIns;
        }
    }
}