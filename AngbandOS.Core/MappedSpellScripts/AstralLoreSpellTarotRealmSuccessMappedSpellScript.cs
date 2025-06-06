namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AstralLoreSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AstralLoreSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AstralLoreTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(IdentifyItemFullyScript) };
}