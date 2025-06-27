namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MageZapSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ZapFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.MageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MageZapScript) };
}
