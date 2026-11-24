using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ItemClassGameConfiguration : NonCompositeSingletonGameConfiguration
{
    /// <summary>
    /// Returns the capitalized name of a singular item that the class represents.  This name can be used in a format like 'Your {0}'
    /// </summary>
    [ConfigurationProperty("string",
        Title = "Name",
        Description = "The capitalized singular name of the item represented by this item class.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("bool",
        Title = "Allow Stomp",
        Description = "Determines whether items of this class allow the player to stomp them.")]
    public virtual bool AllowStomp { get; set; } = true;

    [ConfigurationProperty("int",
        Title = "Number of Flavors to Generate",
        Description = "The number of flavors to generate for items of this item class.")]
    public virtual int NumberOfFlavorsToGenerate { get; set; } = 0;

    /// <summary>
    /// Returns the names of all of the flavors to be assigned to items of this item class;or null, if items should use the <see cref="EffectiveAttributeSet"/>.  Null is returned
    /// when an item has a predefined flavor.  Apple juice, water and slime-mold item factories use pre-defined flavors. 
    /// </summary>
    [ConfigurationProperty("string[]?",
        Title = "Item Flavor Binding Keys",
        Description = "The binding keys of the flavors assigned to items of this item class, or null when items should use the effective attribute set or have a predefined flavor.")]
    public virtual string[]? ItemFlavorBindingKeys { get; set; } = null;
}