namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampiricBrandingSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(VampiricBrandingDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.BrandWeaponAsVampiricScript) };
}