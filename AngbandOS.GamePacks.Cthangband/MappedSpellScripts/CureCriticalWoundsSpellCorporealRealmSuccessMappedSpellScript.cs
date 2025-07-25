namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureCriticalWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureCriticalWoundsCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureCriticalWounds8d10Script) };
}