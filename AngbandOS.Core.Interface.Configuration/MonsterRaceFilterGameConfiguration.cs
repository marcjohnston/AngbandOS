using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MonsterRaceFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]?",
        Title = "Any Symbol Binding Keys",
        Summary = "The symbol binding keys used to match any specified symbols.")]
    public virtual string[]? AnySymbolBindingKeys => null;

    [ConfigurationProperty("string[]?",
        Title = "Any Monster Race Binding Keys",
        Summary = "The monster race binding keys used to match any specified monster races.")]
    public virtual string[]? AnyMonsterRaceBindingKeys => null;

    [ConfigurationProperty("string[]?",
        Title = "Any Monster Spell Binding Keys",
        Summary = "The monster spell binding keys used to match any specified monster spells.")]
    public virtual string[]? AnyMonsterSpellBindingKeys => null;
}
