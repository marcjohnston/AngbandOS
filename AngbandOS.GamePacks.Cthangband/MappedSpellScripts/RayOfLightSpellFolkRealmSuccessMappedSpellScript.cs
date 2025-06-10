namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RayOfLightSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RayOfLightFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RayOfLightScript) };
}