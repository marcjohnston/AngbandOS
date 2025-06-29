namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class TarotDrawSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(TarotDrawTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.TarotDrawScript) };
}