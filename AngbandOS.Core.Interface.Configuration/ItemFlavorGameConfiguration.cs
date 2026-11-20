using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using AngbandOS.Core.Interface.Configuration.Annotations;

public class ItemFlavorGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Symbol Name",
        Summary = "The name of the symbol used to represent the item flavor.")]
    public virtual string SymbolName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Summary = "The color used to display the item flavor.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("string",
        Title = "Name",
        Summary = "The name of the item flavor.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("bool",
        Title = "Can Be Assigned",
        Summary = "Determines whether this item flavor can be assigned to an item.")]
    public virtual bool CanBeAssigned { get; set; }
}