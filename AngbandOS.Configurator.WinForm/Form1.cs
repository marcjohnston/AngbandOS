using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Configurator.WinForm
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<TreeNode, DefinitionMetadata> _definitionMetadataByTreeNode = new Dictionary<TreeNode, DefinitionMetadata>();
        private readonly Configuration configuration = new Configuration();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameServer gameServer = new GameServer();
            DefinitionMetadata[] definitionMetadata = gameServer.GetMetadata();
            List<DefinitionMetadata> settingDefinitions = new List<DefinitionMetadata>();
            List<DefinitionMetadata> collectionDefinitions = new List<DefinitionMetadata>();
            foreach (DefinitionMetadata definition in definitionMetadata)
            {
                if (definition.Title == null)
                {
                    definition.Title = definition.PropertyName;
                }
                if (definition.IsArray)
                {
                    collectionDefinitions.Add(definition);
                }
                else
                {
                    settingDefinitions.Add(definition);
                }
            }
            collectionDefinitions.Sort((a, b) => String.Compare(a.Title, b.Title));
            PopulateSettings(settingDefinitions.ToArray());
            PopulateCollections(collectionDefinitions.ToArray());
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Text == "Settings")
            {
                return;
            }

            DefinitionMetadata definitionMetadata = _definitionMetadataByTreeNode[e.Node];
            RenderCollection(definitionMetadata);
        }

        private void RenderCollection(DefinitionMetadata definitionMetadata)
        {
            collectionLabel.Text = definitionMetadata.Title;
            descriptionTextBox.Text = definitionMetadata?.Description;
        }

        private void PopulateSettings(DefinitionMetadata[] definitionMetadata)
        {
            treeView1.Nodes.Add(new TreeNode("Settings"));
            foreach (DefinitionMetadata definition in definitionMetadata)
            {
                string title = definition.Title ?? definition.PropertyName;
            }

        }

        private void PopulateCollections(DefinitionMetadata[] definitionMetadata)
        {
            foreach (DefinitionMetadata definition in definitionMetadata)
            {
                string title = definition.Title ?? definition.PropertyName;
                TreeNode treeNode = new TreeNode(title);
                _definitionMetadataByTreeNode.Add(treeNode, definition);
                treeView1.Nodes.Add(treeNode);
            }
        }
    }
}