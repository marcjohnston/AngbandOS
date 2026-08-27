namespace AngbandOS.GamePacks.Cthangband;

internal class ConjureElementalSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(ConjureElementalTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Elemental1xPet1In2SummonWeightedRandom) };
}