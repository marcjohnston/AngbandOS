namespace AngbandOS.Core.MappedSpellScripts;

[Serializable]
internal class AstralBrandingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScript
{
    private AstralBrandingSpellTarotRealmSuccessMappedSpellScript(Game game) : base(game) { }
    public override string NamespaceKey => MappedSpellScript.SuccessNamespaceKey;
    protected override string SpellBindingKey => nameof(AstralBrandingTarotSpell);
    protected override string? RealmBindingKey => nameof(TarotRealm);
    protected override string[]? CastSpellScriptBindingKeys => new string[] { nameof(BrandWeaponWithAstraScript) };
}