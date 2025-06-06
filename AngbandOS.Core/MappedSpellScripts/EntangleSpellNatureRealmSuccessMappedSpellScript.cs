namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class EntangleSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private EntangleSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(EntangleNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(OldSlowAtLos1xProjectileScript) };
}