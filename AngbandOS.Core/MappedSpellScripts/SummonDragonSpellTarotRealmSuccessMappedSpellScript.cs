namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonDragonSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonDragonSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonDragonTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonDragonScript) };
}