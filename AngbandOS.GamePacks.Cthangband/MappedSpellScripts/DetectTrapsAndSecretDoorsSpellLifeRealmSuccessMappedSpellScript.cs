namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectTrapsAndSecretDoorsSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectTrapsAndSecretDoorsLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectDoorsTrapsAndStairsScript) };
}