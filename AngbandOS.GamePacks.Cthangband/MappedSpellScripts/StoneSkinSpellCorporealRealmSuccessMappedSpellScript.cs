namespace AngbandOS.GamePacks.Cthangband;

internal class StoneSkinSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(StoneSkinCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Stoneskin30P1d20TimerScript) };
}