using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Spell",
    EntityNoun = "spell")]
public class SpellGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Name",
        Summary = "Returns the name of the spell, as rendered to the save game.",
        DataType = "string")]
    public virtual string Name { get; set; }

    [ConfigurationMetadata(
        Title = "Learned Details",
        Summary = "Returns details about the spell, blank if there are no details, or null if the details should be retrieved from the associated scripts configured when the spell succeeds.",
        DataType = "string?")]
    public virtual string? LearnedDetails { get; set; } = null;
}
