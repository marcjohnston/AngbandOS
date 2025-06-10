namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SeeInvisibleSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SeeInvisibleCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SeeInvisible1d24p24Script) };
}