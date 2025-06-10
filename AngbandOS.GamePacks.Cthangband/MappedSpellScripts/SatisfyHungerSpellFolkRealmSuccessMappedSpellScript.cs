namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SatisfyHungerSpellFolkRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SatisfyHungerFolkSpell);
    public override string? RealmBindingKey => nameof(FolkRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.SatisfyHungerScript) };
}