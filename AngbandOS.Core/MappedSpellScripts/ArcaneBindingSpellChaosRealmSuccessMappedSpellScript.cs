namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ArcaneBindingSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ArcaneBindingSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ArcaneBindingChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ArcaneBindingScript) };
}