namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class LifeRealmFailureMappedSpellScript : MappedSpellScript
{
    private LifeRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(LifeRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}