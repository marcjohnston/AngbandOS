namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EnchantWeaponSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EnchantWeaponSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.EnchantWeaponScript) };
}