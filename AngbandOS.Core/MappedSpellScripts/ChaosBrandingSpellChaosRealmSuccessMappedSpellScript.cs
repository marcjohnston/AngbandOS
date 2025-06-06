namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class ChaosBrandingSpellChaosRealmSuccessMappedSpellScript : MappedSpellScript
{
    private ChaosBrandingSpellChaosRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(ChaosBrandingChaosSpell);
    protected override string? RealmBindingKey => nameof(ChaosRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BrandWeaponWithChaosScript) };
}