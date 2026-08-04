namespace AngbandOS.GamePacks.Cthangband;

internal class MageCharacterClassOrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageOrbOfEntropyProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
