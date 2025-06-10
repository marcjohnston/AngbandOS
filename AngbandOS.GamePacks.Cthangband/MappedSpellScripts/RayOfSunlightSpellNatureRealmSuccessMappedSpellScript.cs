namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RayOfSunlightSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RayOfSunlightNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RayOfSunlightScript) };
}