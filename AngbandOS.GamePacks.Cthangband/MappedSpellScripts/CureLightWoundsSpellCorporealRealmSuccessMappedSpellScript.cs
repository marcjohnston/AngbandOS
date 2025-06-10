namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureLightWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureLightWoundsCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureLightWounds2d10Script) };
}