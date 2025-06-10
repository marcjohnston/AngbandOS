namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class AstralBrandingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(AstralBrandingTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.BrandWeaponWithAstraScript) };
}