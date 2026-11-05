using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class MonsterRaceFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationPropertyAttribute(
        Title = "Any Symbol Binding Keys",
        Summary = "The symbol binding keys used to match any specified symbols.",
        DataType = "string[]?")]
    public virtual string[]? AnySymbolBindingKeys => null;

    [ConfigurationPropertyAttribute(
        Title = "Any Monster Race Binding Keys",
        Summary = "The monster race binding keys used to match any specified monster races.",
        DataType = "string[]?")]
    public virtual string[]? AnyMonsterRaceBindingKeys => null;

    [ConfigurationPropertyAttribute(
        Title = "Any Monster Spell Binding Keys",
        Summary = "The monster spell binding keys used to match any specified monster spells.",
        DataType = "string[]?")]
    public virtual string[]? AnyMonsterSpellBindingKeys => null;
}
