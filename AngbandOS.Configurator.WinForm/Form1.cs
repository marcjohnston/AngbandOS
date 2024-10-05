using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.PersistentStorage;
using System.Reflection;
using System.Windows.Forms;

namespace AngbandOS.Configurator.WinForm
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Maps tree nodes to their associated PropertyMetadata.
        /// </summary>
        private readonly Dictionary<TreeNode, PropertyMetadata> _definitionMetadataByTreeNode = new Dictionary<TreeNode, PropertyMetadata>();
        private Configuration configuration;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string saveFilename = Path.Combine(savePath, "My Games\\angbandos.savefile");
            ICorePersistentStorage persistentStorage = new FileSystemPersistentStorage(saveFilename);
            configuration = Configuration.LoadConfiguration(persistentStorage);
            PropertyMetadata[] configurationMetadata = Configuration.Metadata;
            Dictionary<string, TreeNodeCollection> categoryTreeNodeCollectionDictionary = new Dictionary<string, TreeNodeCollection>();

            foreach (PropertyMetadata propertyMetadata in configurationMetadata)
            {
                TreeNodeCollection? categoryTreeNodeCollection = null;
                if (propertyMetadata.CategoryTitle == "")
                {
                    // Put the property into the root node.
                    categoryTreeNodeCollection = treeView1.Nodes;
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
                }

                // Add a node to the category collection.
                TreeNode propertyMetadataTreeNode = categoryTreeNodeCollection.Add(propertyMetadata.PropertyName);

                // Track the node.
                _definitionMetadataByTreeNode.Add(propertyMetadataTreeNode, propertyMetadata);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }

            // Retieve the property metadata.  If the node isn't in our list, then it is a parent node we do not handle.
            if (!_definitionMetadataByTreeNode.TryGetValue(treeView1.SelectedNode, out PropertyMetadata? propertyMetadata))
                return;

            UserControl propertyUserControl;
            switch (propertyMetadata)
            {
                case CollectionPropertyMetadata collectionPropertyMetadata:
                    propertyUserControl = new CollectionPropertyUserControl(collectionPropertyMetadata, configuration, "configuration");
                    break;
                case BooleanPropertyMetadata booleanPropertyMetadata:
                    propertyUserControl = new BooleanPropertyUserControl(booleanPropertyMetadata, configuration);
                    break;
                case StringPropertyMetadata stringPropertyMetadata:
                    propertyUserControl = new StringPropertyUserControl(stringPropertyMetadata, configuration);
                    break;
                case IntegerPropertyMetadata integerPropertyMetadata:
                    propertyUserControl = new IntegerPropertyUserControl(integerPropertyMetadata, configuration);
                    break;
                case TuplePropertyMetadata tuplePropertyMetadata:
                    propertyUserControl = new TuplePropertyUserControl(tuplePropertyMetadata, configuration);
                    break;
                default:
                    MessageBox.Show($"An error occurred building the root metadata tree while processing the metadata property {propertyMetadata.PropertyName}.  The metadata property type {propertyMetadata.GetType().Name} is not supported.");
                    return;
            }
            splitContainer2.Panel2.Controls.Clear();
            propertyUserControl.Dock = DockStyle.Fill;
            splitContainer2.Panel2.Controls.Add(propertyUserControl);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
        }
    }
}