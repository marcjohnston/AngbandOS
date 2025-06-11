namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AstralSpyingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AstralSpyingTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Add1d30p25TelepathyTimer) };
}