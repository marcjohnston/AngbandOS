namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class NatureRealmFailureMappedSpellScript : MappedSpellScript
{
    private NatureRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}