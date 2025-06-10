namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectMonstersSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectMonstersFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectNormalMonstersScript) };
}