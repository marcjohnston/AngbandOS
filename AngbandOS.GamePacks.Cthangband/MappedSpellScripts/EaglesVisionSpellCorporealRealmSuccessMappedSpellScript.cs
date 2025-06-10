namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class EaglesVisionSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(EaglesVisionCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.EaglesVisionScript) };
}