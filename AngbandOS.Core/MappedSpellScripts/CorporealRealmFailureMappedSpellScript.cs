namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class CorporealRealmFailureMappedSpellScript : MappedSpellScript
{
    private CorporealRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(CorporealRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}