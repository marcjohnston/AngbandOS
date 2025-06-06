namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FistOfForceSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FistOfForceSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FistOfForceChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FistOfForceScript) };
}