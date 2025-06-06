namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonSpidersSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonSpidersSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonSpidersTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonSpiderScript) };
}