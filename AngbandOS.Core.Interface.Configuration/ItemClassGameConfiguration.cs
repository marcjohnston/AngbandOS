using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemClassGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    [ConfigurationMetadata(
        Title = "Name",
        Summary = "The capitalized singular name of the item represented by this item class.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Allow Stomp",
        Summary = "Determines whether items of this class allow the player to stomp them.",
        DataType = "bool")]
    public virtual bool AllowStomp { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Number of Flavors to Generate",
        Summary = "The number of flavors to generate for items of this item class.",
        DataType = "int")]
    public virtual int NumberOfFlavorsToGenerate { get; set; } = 0;

    /// <summary>
    /// Returns the names of all of the flavors to be assigned to items of this item class;or null, if items should use the <see cref="EffectiveAttributeSet"/>.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    [ConfigurationMetadata(
        Title = "Item Flavor Binding Keys",
        Summary = "The binding keys of the flavors assigned to items of this item class, or null when items should use the effective attribute set or have a predefined flavor.",
        DataType = "string[]?")]
    public virtual string[]? ItemFlavorBindingKeys { get; set; } = null;
}