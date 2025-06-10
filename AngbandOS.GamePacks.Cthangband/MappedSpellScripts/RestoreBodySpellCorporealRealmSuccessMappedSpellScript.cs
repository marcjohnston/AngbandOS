namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class RestoreBodySpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(RestoreBodyCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.RestoreBodyScript) };
}