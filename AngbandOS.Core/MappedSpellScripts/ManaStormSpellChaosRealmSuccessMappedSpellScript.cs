namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ManaStormSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ManaStormSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ManaStormChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(ManaStormScript) };
}