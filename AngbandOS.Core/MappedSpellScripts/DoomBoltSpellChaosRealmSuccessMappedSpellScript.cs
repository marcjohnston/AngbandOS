namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class DoomBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private DoomBoltSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(DoomBoltChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(DoomBoltScript) };
}