namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DimensionDoorSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DimensionDoorSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CreateDimensionDoorScript) };
}