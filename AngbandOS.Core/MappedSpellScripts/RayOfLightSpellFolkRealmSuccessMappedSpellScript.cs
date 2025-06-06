namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class RayOfLightSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private RayOfLightSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(RayOfLightFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(RayOfLightScript) };
}