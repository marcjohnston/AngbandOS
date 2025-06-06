namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonDemonSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonDemonSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonDemonTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DemonSummonWeightedRandom) };
}