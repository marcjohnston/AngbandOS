namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageDarkBoltSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DarkBoltDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MageDarkBoltScript) };
}
