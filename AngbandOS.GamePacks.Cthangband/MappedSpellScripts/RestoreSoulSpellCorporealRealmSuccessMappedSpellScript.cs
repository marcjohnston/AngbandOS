namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RestoreSoulSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RestoreSoulCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RestoreLevelScript) };
}