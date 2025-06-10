namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DimensionDoorSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DimensionDoorTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CreateDimensionDoorScript) };
}