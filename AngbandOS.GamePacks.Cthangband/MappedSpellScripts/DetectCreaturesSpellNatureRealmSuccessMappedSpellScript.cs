namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DetectCreaturesSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(DetectCreaturesNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.DetectNormalMonstersScript) };
}