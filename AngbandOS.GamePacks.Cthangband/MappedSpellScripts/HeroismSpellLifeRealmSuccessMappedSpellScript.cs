namespace AngbandOS.GamePacks.Cthangband;

internal class HeroismSpellLifeRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(HeroismLifeSpell);
    public override string? RealmBindingKey => nameof(LifeRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.Heroism1d25p25RestoreHealth10ResetFearScript) };
}