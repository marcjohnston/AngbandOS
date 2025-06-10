namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AstralLoreSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AstralLoreTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.IdentifyItemFullyScript) };
}