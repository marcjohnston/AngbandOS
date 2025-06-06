namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ExtraDimensionalBeingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ExtraDimensionalBeingSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ExtraDimensionalBeingTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ExtraDimensionalBeingScript) };
}