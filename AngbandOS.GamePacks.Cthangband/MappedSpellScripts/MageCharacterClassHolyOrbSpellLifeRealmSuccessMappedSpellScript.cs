namespace AngbandOS.GamePacks.Cthangband;

internal class MageCharacterClassHolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageHolyOrbProjectileScript) };
    public override int? MaximumExperienceLevel => 29;
}
