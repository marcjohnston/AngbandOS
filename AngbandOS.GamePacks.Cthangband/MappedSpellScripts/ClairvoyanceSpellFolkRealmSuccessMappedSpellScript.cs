namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ClairvoyanceSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ClairvoyanceFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ClairvoyanceScript) };
}