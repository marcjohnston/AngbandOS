namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageCharacterClassLevel30HolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageLevel30HolyOrbScript) };
    public override int? MinimumExperienceLevel => 30;
}
