namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageCharacterClassLevel30OrbOfEntropySpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(OrbOfEntropyDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageLevel30OrbOfEntropyProjectileScript) };
    public override int? MinimumExperienceLevel => 30;
}