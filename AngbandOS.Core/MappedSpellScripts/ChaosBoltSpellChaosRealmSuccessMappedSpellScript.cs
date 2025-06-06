namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ChaosBoltSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ChaosBoltSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ChaosBoltChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ChaosBoltScript) };
}