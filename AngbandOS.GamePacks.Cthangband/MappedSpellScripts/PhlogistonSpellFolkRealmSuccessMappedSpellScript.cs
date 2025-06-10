namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class PhlogistonSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PhlogistonFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CreatePhlogistonScript) };
}