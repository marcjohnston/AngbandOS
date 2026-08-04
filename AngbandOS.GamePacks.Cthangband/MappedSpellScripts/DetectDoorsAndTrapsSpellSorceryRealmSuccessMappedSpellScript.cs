namespace AngbandOS.GamePacks.Cthangband;

internal class DetectDoorsAndTrapsSpellSorceryRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectDoorsAndTrapsSorcerySpell);
    public override string? RealmBindingKey => nameof(SorceryRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectDoorsTrapsAndStairsScript) };
}