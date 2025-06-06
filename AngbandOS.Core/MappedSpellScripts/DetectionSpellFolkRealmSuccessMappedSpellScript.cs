namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DetectionSpellFolkRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DetectionSpellFolkRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DetectionFolkSpell);
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DetectionScript) };
}