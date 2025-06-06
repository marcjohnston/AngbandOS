namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TarotRealmFailureMappedSpellScript : MappedSpellScript
{
    private TarotRealmFailureMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.FailureNamespaceKey;
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { };
}