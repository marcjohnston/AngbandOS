namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CureMediumWoundsSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(CureMediumWoundsCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.CureMediumWounds4d10Script) };
}