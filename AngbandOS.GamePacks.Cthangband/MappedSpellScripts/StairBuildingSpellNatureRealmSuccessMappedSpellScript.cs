namespace AngbandOS.GamePacks.Cthangband;

internal class StairBuildingSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(StairBuildingNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CreateStairsScript) };
}