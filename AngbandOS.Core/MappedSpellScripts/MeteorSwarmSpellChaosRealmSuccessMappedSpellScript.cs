namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class MeteorSwarmSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private MeteorSwarmSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(MeteorSwarmChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(MeteorStormScript) };
}