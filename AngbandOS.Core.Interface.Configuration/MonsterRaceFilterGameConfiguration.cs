using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Monster Race Filter",
    EntityNoun = "MonsterRaceFilter")]
public class MonsterRaceFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Any Symbol Binding Keys",
        Summary = "The symbol binding keys used to match any specified symbols.",
        DataType = "string[]?")]
    public virtual string[]? AnySymbolBindingKeys => null;

    [ConfigurationMetadataAttribute(
        Title = "Any Monster Race Binding Keys",
        Summary = "The monster race binding keys used to match any specified monster races.",
        DataType = "string[]?")]
    public virtual string[]? AnyMonsterRaceBindingKeys => null;

    [ConfigurationMetadataAttribute(
        Title = "Any Monster Spell Binding Keys",
        Summary = "The monster spell binding keys used to match any specified monster spells.",
        DataType = "string[]?")]
    public virtual string[]? AnyMonsterSpellBindingKeys => null;
}
