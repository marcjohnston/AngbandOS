namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DispelEvilSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DispelEvilLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DispelEvilAtLos4xProjectileScript) };
}