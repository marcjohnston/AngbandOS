namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EarthquakeSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EarthquakeNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.EarthquakeR10Script) };
}