namespace AngbandOS.GamePacks.Cthangband;

internal class DetectObjectsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectObjectsFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectNormalObjectsScript) };
}