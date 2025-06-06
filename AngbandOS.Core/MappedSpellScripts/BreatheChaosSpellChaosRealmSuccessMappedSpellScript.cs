namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class BreatheChaosSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private BreatheChaosSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(BreatheChaosChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BreatheChaosScript) };
}