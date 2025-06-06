namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FolkRealmFailureMappedSpellScript : MappedSpellScript
{
    private FolkRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(FolkRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}