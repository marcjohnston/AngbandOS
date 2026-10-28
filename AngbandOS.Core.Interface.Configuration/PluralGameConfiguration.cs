using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Plural",
    EntityNoun = "plural")]
public class PluralGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Plural Form",
        Summary = "Specifies the pluralized form of the key.",
        DataType = "string")]
    public virtual string PluralForm { get; set; }
}
