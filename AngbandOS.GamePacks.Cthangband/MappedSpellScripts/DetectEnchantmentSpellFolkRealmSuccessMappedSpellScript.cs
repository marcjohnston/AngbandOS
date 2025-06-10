namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectEnchantmentSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectEnchantmentFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectMagicalObjectsScript) };
}