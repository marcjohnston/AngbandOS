namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class SummonReptilesSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private SummonReptilesSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(SummonReptilesTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SummonReptileScript) };
}