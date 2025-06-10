namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class WallOfStoneSpellNatureRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WallOfStoneNatureSpell);
    public override string? RealmBindingKey => nameof(NatureRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.WallOfStoneScript) };
}