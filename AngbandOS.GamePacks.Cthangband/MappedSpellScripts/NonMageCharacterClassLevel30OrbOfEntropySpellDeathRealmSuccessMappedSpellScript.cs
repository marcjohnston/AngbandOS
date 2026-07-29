namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NonMageCharacterClassLevel30OrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NonMageLevel30OrbOfEntropyProjectileScript) };
    public override int? MinimumExperienceLevel => 30;
}
