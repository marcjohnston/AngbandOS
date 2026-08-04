namespace AngbandOS.GamePacks.Cthangband;

internal class BatsSenseSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(BatsSenseCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.MapAreaScript) };
}