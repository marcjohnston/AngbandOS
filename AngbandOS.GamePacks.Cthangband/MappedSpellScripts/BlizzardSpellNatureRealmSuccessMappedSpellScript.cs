namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class BlizzardSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BlizzardNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ColdXP70RXO12P3ProjectileScript) };
}