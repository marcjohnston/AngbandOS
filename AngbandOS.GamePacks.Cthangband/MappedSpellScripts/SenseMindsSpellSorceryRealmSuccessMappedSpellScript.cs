namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SenseMindsSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SenseMindsSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Add1d30p25TelepathyTimer) };
}