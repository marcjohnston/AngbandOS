namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonGreaterUndeadSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonGreaterUndeadSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonGreaterUndeadTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonGreaterUndeadScript) };
}