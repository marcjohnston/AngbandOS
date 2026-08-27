namespace AngbandOS.GamePacks.Cthangband;

internal class SummonGreaterUndeadSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonGreaterUndeadTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SummonGreaterUndeadScript) };
}