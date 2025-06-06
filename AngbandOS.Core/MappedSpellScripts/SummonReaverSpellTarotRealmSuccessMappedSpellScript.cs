namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonReaverSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonReaverSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonReaverTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonReaverScript) };
}