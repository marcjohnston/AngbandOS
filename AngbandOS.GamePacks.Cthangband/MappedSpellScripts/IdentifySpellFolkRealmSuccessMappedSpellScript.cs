namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class IdentifySpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(IdentifyFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.IdentifyItemScript) };
}