namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectTreasureSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectTreasureFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectTreasureAndGoldScript) };
}