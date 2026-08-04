namespace AngbandOS.GamePacks.Cthangband;

internal class HighMageCharacterClassManaBurstScriptSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ManaBurstChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageManaBurstProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
