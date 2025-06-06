namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ConjureElementalSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ConjureElementalSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ConjureElementalTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonElementalScript) };
}