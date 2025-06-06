namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectObjectsSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectObjectsSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectObjectsFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectNormalObjectsScript) };
}