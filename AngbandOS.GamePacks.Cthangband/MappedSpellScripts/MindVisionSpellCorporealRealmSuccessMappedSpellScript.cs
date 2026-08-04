namespace AngbandOS.GamePacks.Cthangband;

internal class MindVisionSpellCorporealRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(MindVisionCorporealSpell);
    public override string? RealmBindingKey => nameof(CorporealRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Telepathy1d30p25TimerScript) };
}