namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class FireBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private FireBoltSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(FireBoltChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(FireBoltOrBeamOfFireScript) };
}