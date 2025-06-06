namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonUndeadSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonUndeadSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonUndeadTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonUndeadScript) };
}