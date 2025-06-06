namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ChainLightningSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ChainLightningSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ChainLightningChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ChainLightingScript) };
}