using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class CollectionPropertyUserControl : UserControl, IPropertyUserControl
    {
        private readonly CollectionPropertyMetadata CollectionPropertyMetadata;
        private readonly IGameConfiguration Configuration;
        private readonly string Breadcrumb;

        public CollectionPropertyUserControl(CollectionPropertyMetadata collectionPropertyMetadata, IGameConfiguration configuration, string breadcrumb)
        {
            InitializeComponent();

            CollectionPropertyMetadata = collectionPropertyMetadata;
            Configuration = configuration;
            Breadcrumb = breadcrumb;

            string title = collectionPropertyMetadata.Title ?? collectionPropertyMetadata.PropertyName;
            titleLabel.Text = title;
            descriptionLabel.Text = collectionPropertyMetadata.Description;

            PropertyInfo? collectionPropertyInfo = Configuration.GetType().GetProperty(CollectionPropertyMetadata.PropertyName);
            if (collectionPropertyInfo == null)
            {
                MessageBox.Show($"The {Breadcrumb}/{CollectionPropertyMetadata.PropertyName} metadata references a configuration property that is not valid.");
                return;
            }

            // A collection refers to an array of a complex object.
            IGameConfiguration[]? collectionConfiguration = (IGameConfiguration[]?)collectionPropertyInfo.GetValue(Configuration);

            // Check to see if there are entities in the collection.
            if (collectionConfiguration != null)
            {
                // Enumerate the entities and put them into the listbox.
                foreach (IGameConfiguration collectionConfigurationItem in collectionConfiguration)
                {
                    collectionEntitiesListBox.Items.Add(collectionConfigurationItem);
                }
            }
        }

        private void collectionEntitiesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            // Get the entity that the user selected from the list box.
            IGameConfiguration entityConfiguration = (IGameConfiguration)collectionEntitiesListBox.SelectedItem!; // ! is valid because list items will always be an object.
            MultiPropertyUserControl multiPropertyUserControl = new MultiPropertyUserControl(CollectionPropertyMetadata.PropertiesMetadata, entityConfiguration, $"{Breadcrumb}");

      //      splitContainer1.Panel2.SuspendLayout();
            splitContainer1.Panel2.Controls.Clear();
            multiPropertyUserControl.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(multiPropertyUserControl);
       //     splitContainer1.Panel2.ResumeLayout();
        }
    }
}
