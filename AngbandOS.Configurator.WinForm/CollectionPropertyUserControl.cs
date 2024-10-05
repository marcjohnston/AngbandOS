using AngbandOS.Core.Interface;
using System.Reflection;

namespace AngbandOS.Configurator.WinForm
{
    public partial class CollectionPropertyUserControl : UserControl, IPropertyUserControl
    {
        private readonly CollectionPropertyMetadata CollectionPropertyMetadata;
        private readonly IConfiguration Configuration;
        private readonly string Breadcrumb;

        public CollectionPropertyUserControl(CollectionPropertyMetadata collectionPropertyMetadata, IConfiguration configuration, string breadcrumb)
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
                MessageBox.Show($"The {Breadcrumb} references doesn't have the associated property {CollectionPropertyMetadata.PropertyName}.");
                return;
            }

            // A collection refers to an array of a complex object.
            IConfiguration[]? collectionConfiguration = (IConfiguration[]?)collectionPropertyInfo.GetValue(Configuration);

            // Check to see if there are entities in the collection.
            if (collectionConfiguration != null)
            {
                // Enumerate the entities and put them into the listbox.
                foreach (IConfiguration collectionConfigurationItem in collectionConfiguration)
                {
                    collectionEntitiesListBox.Items.Add(collectionConfigurationItem);
                }
            }
        }

        private void collectionEntitiesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            //IConfiguration? collectionConfiguration = (IConfiguration?)CollectionPropertyInfo.GetValue(Configuration);

            //foreach (PropertyMetadata propertyMetadata in CollectionPropertyMetadata.PropertiesMetadata)
            //{
            //    PropertyInfo propertyInfo = Configuration.GetType().GetProperty(CollectionPropertyMetadata.PropertyName);
            //    UserControl propertyUserControl;
            //    switch (propertyMetadata)
            //    {
            //        case BooleanPropertyMetadata booleanPropertyMetadata:
            //            propertyUserControl = new BooleanPropertyUserControl(booleanPropertyMetadata, collectionConfiguration[0]);
            //            break;
            //        case StringPropertyMetadata stringPropertyMetadata:
            //            propertyUserControl = new StringPropertyUserControl(stringPropertyMetadata, collectionConfiguration[0]);
            //            break;
            //        case IntegerPropertyMetadata integerPropertyMetadata:
            //            propertyUserControl = new IntegerPropertyUserControl(integerPropertyMetadata, collectionConfiguration[0]);
            //            break;
            //        case TuplePropertyMetadata tuplePropertyMetadata:
            //            propertyUserControl = new TuplePropertyUserControl(tuplePropertyMetadata, collectionConfiguration[0]);
            //            break;
            //        default:
            //            throw new Exception("Unsupported metadata property.");
            //    }
            //    //flowLayoutPanel1.Controls.Add(propertyUserControl);
            //}
        }
    }
}
