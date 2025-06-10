namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PhantasmalServantSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PhantasmalServantTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.PhantasmalServantScript) };
}