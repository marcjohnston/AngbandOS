namespace AngbandOS.GamePacks.Cthangband;

internal class ElementalBrandingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ElementalBrandingNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.BrandWeaponWithFireOrIceScript) };
}