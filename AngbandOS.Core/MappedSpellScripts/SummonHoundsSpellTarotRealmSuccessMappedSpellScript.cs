namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonHoundsSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonHoundsSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonHoundsTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonHoundsScript) };
}