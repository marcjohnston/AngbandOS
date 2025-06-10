namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectDoorsAndTrapsSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectDoorsAndTrapsNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectDoorsTrapsAndStairsScript) };
}