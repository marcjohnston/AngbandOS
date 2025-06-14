namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageDarkBoltSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DarkBoltDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageDarkBoltScript) };
}