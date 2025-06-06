namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonAncientDragonSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonAncientDragonSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonAncientDragonTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(AncientDragonSummonWeightedRandom) };
}