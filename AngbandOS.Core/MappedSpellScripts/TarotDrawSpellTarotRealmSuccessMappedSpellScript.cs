namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class TarotDrawSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private TarotDrawSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(TarotDrawTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(TarotDrawScript) };
}