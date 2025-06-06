namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class GravityBeamSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private GravityBeamSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(GravityBeamChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(GravityBeamScript) };
}