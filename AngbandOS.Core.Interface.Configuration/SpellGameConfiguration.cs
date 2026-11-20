using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Name",
        Summary = "Returns the name of the spell, as rendered to the save game.")]
    public virtual string Name { get; set; }

    [ConfigurationProperty("string?",
        Title = "Learned Details",
        Summary = "Returns details about the spell, blank if there are no details, or null if the details should be retrieved from the associated scripts configured when the spell succeeds.")]
    public virtual string? LearnedDetails { get; set; } = null;
}
