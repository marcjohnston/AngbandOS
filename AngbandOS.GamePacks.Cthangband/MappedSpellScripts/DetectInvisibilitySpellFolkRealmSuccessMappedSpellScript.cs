namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectInvisibilitySpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectInvisibilityFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectInvisibilityScript) };
}