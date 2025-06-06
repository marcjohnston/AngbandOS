namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ElementalBrandingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ElementalBrandingSpellNatureRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ElementalBrandingNatureSpell);
    protected override string? RealmBindingKey => nameof(NatureRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BrandWeaponWithFireOrIceScript) };
}