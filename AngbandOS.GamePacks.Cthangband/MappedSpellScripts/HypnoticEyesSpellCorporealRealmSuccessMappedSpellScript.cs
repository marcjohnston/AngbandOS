namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HypnoticEyesSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HypnoticEyesCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.HypnoticEyesScript) };
}