using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class PluralGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Plural Form",
        Summary = "Specifies the pluralized form of the key.")]
    public virtual string PluralForm { get; set; }
}
