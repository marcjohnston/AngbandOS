namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class NaturesWrathSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private NaturesWrathSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(NaturesWrathNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(NaturesWrathScript) };
}