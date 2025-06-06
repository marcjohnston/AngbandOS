namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class LightningStormSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private LightningStormSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(LightningStormNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(LightningStormScript) };
}