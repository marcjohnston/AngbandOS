namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageCharacterClassHolyOrbSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HolyOrbLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MageHolyOrbProjectileScript) };
}
