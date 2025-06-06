namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class VampiricBrandingSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private VampiricBrandingSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(VampiricBrandingDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BrandWeaponAsVampiricScript) };
}