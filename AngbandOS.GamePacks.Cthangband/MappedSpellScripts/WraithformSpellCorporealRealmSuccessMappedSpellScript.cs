namespace AngbandOS.GamePacks.Cthangband;

internal class WraithformSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(WraithformCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(EtherealnessXO2dX02TimerScript) };
}