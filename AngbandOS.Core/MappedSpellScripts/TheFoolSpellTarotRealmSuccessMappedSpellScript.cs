namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TheFoolSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TheFoolSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TheFoolTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BizarreSummonWeightedRandom) };
}