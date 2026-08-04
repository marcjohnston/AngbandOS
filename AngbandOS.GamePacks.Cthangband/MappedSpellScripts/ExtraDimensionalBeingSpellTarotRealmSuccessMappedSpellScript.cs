namespace AngbandOS.GamePacks.Cthangband;

internal class ExtraDimensionalBeingSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ExtraDimensionalBeingTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(SystemScriptsEnum.ExtraDimensionalBeingScript) };
}