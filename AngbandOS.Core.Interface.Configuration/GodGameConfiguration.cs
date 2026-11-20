using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class GodGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Long Name",
        Summary = "The full name of the god.")]
    public virtual string LongName { get; set; }

    [ConfigurationProperty("string",
        Title = "Short Name",
        Summary = "The abbreviated name of the god.")]
    public virtual string ShortName { get; set; }

    [ConfigurationProperty("string",
        Title = "Favor Description",
        Summary = "A description of the favor granted by the god.")]
    public virtual string FavorDescription { get; set; }
}