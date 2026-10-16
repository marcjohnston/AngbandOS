using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(Title = "God", EntityNoun = "god")]
public class GodGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(Title = "Long Name", Summary = "The full name of the god.", DataType = "string")]
    public virtual string LongName { get; set; }

    [ConfigurationMetadata(Title = "Short Name", Summary = "The abbreviated name of the god.", DataType = "string")]
    public virtual string ShortName { get; set; }

    [ConfigurationMetadata(Title = "Favor Description", Summary = "A description of the favor granted by the god.", DataType = "string")]
    public virtual string FavorDescription { get; set; }
}