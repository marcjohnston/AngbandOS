using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class SymbolGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("char",
        Title = "Character",
        Summary = "Specifies the character used to render the symbol.")]
    public virtual char Character { get; set; }

    [ConfigurationProperty("char?",
        Title = "Query Character",
        Summary = "Specifies the optional character used when querying the symbol.")]
    public virtual char? QueryCharacter { get; set; } = null;

    [ConfigurationProperty("string",
        Title = "Name",
        Summary = "Specifies the name of the symbol.")]
    public virtual string Name { get; set; }
}
