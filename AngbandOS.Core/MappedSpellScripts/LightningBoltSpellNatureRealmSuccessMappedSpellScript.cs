namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class LightningBoltSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private LightningBoltSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(LightningBoltNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightningBoltScript) };
}