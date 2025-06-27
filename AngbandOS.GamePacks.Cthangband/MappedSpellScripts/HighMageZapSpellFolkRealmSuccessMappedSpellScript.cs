namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighMageZapSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ZapFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string? CharacterClassBindingKey => nameof(CharacterClassesEnum.HighMageCharacterClass);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HighMageZapScript) };
}