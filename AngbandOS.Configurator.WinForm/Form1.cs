using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage;

namespace AngbandOS.Configurator.WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Maps tree nodes to their associated PropertyMetadata.
        /// </summary>
        private readonly Dictionary<TreeNode, PropertyMetadata> _definitionMetadataByTreeNode = new Dictionary<TreeNode, PropertyMetadata>();
        private GameConfiguration configuration;
        private TreeNode GameTreeNode = new TreeNode("Game Setings");
        private PropertyMetadata[] GamePropertiesMetadata;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string saveFilename = Path.Combine(savePath, "My Games\\angbandos.savefile");
            ICorePersistentStorage persistentStorage = new FileSystemCorePersistentStorage(saveFilename);
            configuration = GameConfiguration.LoadConfiguration(persistentStorage);
            PropertyMetadata[] configurationMetadata = GameConfiguration.Metadata;
            Dictionary<string, TreeNodeCollection> categoryTreeNodeCollectionDictionary = new Dictionary<string, TreeNodeCollection>();
            List<PropertyMetadata> gameSettingsPropertyMetadataList = new List<PropertyMetadata>();
            treeView1.Nodes.Add(GameTreeNode);

            foreach (PropertyMetadata propertyMetadata in configurationMetadata)
            {
                TreeNodeCollection? categoryTreeNodeCollection = null;
                if (propertyMetadata.CategoryTitle == "")
                {
                    // Put the property into the game node.
                    gameSettingsPropertyMetadataList.Add(propertyMetadata);
                }
                else
                {
                    // Determine if there is a treenode collection already for this category.
                    if (!categoryTreeNodeCollectionDictionary.TryGetValue(propertyMetadata.CategoryTitle, out categoryTreeNodeCollection))
                    {
                        // There isn't.  Create one and add it to the dictionary.
                        TreeNode categoryTreeNode = new TreeNode();
                        categoryTreeNode.Text = propertyMetadata.CategoryTitle;
                        categoryTreeNodeCollection = categoryTreeNode.Nodes;
                        categoryTreeNodeCollectionDictionary.Add(propertyMetadata.CategoryTitle, categoryTreeNodeCollection);
                        treeView1.Nodes.Add(categoryTreeNode);
                    }

                    // Add a node to the category collection.
                    TreeNode propertyMetadataTreeNode = categoryTreeNodeCollection.Add(propertyMetadata.PropertyName);

                    // Track the node.
                    _definitionMetadataByTreeNode.Add(propertyMetadataTreeNode, propertyMetadata);
                }
            }
            GamePropertiesMetadata = gameSettingsPropertyMetadataList.ToArray();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            splitContainer2.Panel2.Controls.Clear();

            if (e.Node == null)
            {
                return;
            }

            // The next blocks will determine which property user control to render.
            UserControl propertyUserControl;

            // Check to see if the user selected the pre-defined game settings tree node.
            if (e.Node == GameTreeNode)
            {
                propertyUserControl = new MultiPropertyUserControl(GamePropertiesMetadata, configuration, "configuration");
            }
            else
            {
                // Otherwise, retieve the property metadata.  If the node isn't in our list, then it is a parent node we do not handle.
                if (!_definitionMetadataByTreeNode.TryGetValue(treeView1.SelectedNode, out PropertyMetadata? propertyMetadata))
                    return;

                propertyUserControl = new MultiPropertyUserControl(new PropertyMetadata[] { propertyMetadata }, configuration, "configuration");
            }

            propertyUserControl.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(propertyUserControl);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
    }
}