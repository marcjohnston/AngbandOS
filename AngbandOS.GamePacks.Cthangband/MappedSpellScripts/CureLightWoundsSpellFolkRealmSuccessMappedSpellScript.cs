namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureLightWoundsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureLightWoundsFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureLightWounds2d8Script) };
}