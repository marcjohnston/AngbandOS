namespace AngbandOS.GamePacks.Cthangband;

internal class HeroismSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HeroismCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.Heroism1d25p25RestoreHealth10ResetFearScript) };
}