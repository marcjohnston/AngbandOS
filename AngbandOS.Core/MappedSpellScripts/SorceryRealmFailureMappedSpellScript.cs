namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SorceryRealmFailureMappedSpellScript : MappedSpellScript
{
    private SorceryRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(SorceryRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}