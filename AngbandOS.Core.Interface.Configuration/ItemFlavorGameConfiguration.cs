using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Core.Interface.Configuration.Annotations;

[ConfigurationEntityAttribute(
    Title = "Item Flavor",
    EntityNoun = "Item Flavor")]
public class ItemFlavorGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Symbol Name",
        Summary = "The name of the symbol used to represent the item flavor.",
        DataType = "string")]
    public virtual string SymbolName { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Color",
        Summary = "The color used to display the item flavor.",
        DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationMetadataAttribute(
        Title = "Name",
        Summary = "The name of the item flavor.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Can Be Assigned",
        Summary = "Determines whether this item flavor can be assigned to an item.",
        DataType = "bool")]
    public virtual bool CanBeAssigned { get; set; }
}