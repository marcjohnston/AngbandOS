namespace AngbandOS.Core.Interface.Configuration;

public class MonsterRaceFilterGameConfiguration : NonCompositeSingletonGameConfiguration
{
    public virtual string[]? AnySymbolBindingKeys => null;
    public virtual string[]? AnyMonsterRaceBindingKeys => null;
    public virtual string[]? AnyMonsterSpellBindingKeys => null;
}
