using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SymbolGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Character",
        Summary = "Specifies the character used to render the symbol.",
        DataType = "char")]
    public virtual char Character { get; set; }

    [ConfigurationProperty(
        Title = "Query Character",
        Summary = "Specifies the optional character used when querying the symbol.",
        DataType = "char?")]
    public virtual char? QueryCharacter { get; set; } = null;

    [ConfigurationProperty(
        Title = "Name",
        Summary = "Specifies the name of the symbol.",
        DataType = "string")]
    public virtual string Name { get; set; }
}
