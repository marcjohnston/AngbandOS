namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageLevel30CharacterClassHolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageLevel30HolyOrbProjectileScript) };
    public override int? MinimumExperienceLevel => 30;
}
