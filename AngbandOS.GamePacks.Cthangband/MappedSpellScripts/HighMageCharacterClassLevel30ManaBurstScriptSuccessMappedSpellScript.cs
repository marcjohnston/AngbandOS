namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageCharacterClassLevel30ManaBurstScriptSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ManaBurstChaosSpell);
    public override string? RealmBindingKey => nameof(ChaosRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageLevel30ManaBurstProjectileScript) };
    public override int? MinimumExperienceLevel => 30;
}
