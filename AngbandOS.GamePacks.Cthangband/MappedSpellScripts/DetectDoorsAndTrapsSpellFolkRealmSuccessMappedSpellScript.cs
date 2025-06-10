namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectDoorsAndTrapsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectDoorsAndTrapsFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectDoorsTrapsAndStairsScript) };
}