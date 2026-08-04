namespace AngbandOS.GamePacks.Cthangband;

internal class NonMageCharacterClassOrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageOrbOfEntropyProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
