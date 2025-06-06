namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class PoisonBrandingSpellDeathRealmSuccessMappedSpellScript : MappedSpellScript
{
    private PoisonBrandingSpellDeathRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(PoisonBrandingDeathSpell);
    protected override string? RealmBindingKey => nameof(DeathRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BrandWeaponWithPoisonScript) };
}