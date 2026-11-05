using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class GodGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(Title = "Long Name", Summary = "The full name of the god.", DataType = "string")]
    public virtual string LongName { get; set; }

    [ConfigurationProperty(Title = "Short Name", Summary = "The abbreviated name of the god.", DataType = "string")]
    public virtual string ShortName { get; set; }

    [ConfigurationProperty(Title = "Favor Description", Summary = "A description of the favor granted by the god.", DataType = "string")]
    public virtual string FavorDescription { get; set; }
}