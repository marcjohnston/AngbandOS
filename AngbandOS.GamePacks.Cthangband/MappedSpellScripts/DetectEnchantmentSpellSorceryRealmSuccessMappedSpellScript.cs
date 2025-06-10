namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectEnchantmentSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectEnchantmentSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectMagicalObjectsScript) };
}