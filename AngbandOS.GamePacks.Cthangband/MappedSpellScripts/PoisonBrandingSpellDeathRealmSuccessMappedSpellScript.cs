namespace AngbandOS.GamePacks.Cthangband;

internal class PoisonBrandingSpellDeathRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(PoisonBrandingDeathSpell);
    public override string? RealmBindingKey => nameof(DeathRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.BrandWeaponWithPoisonScript) };
}