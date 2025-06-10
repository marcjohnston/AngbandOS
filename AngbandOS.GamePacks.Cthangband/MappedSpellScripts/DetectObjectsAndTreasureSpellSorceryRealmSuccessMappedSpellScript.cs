namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectObjectsAndTreasureSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectObjectsAndTreasureSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectObjectsAndTreasureScript) };
}