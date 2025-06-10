namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindVisionSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MindVisionCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.AddTelepathy25p1d30Script) };
}