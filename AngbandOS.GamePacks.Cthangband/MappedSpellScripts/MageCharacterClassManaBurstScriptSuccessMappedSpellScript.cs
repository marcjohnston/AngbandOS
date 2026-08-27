namespace AngbandOS.GamePacks.Cthangband;

internal class MageCharacterClassManaBurstScriptSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ManaBurstChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageManaBurstProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
