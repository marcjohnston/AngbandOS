namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SummonAnimalSpellTarotRealmSuccessMappedSpellScript : MappedSpellScriptGameConfiguration
{
    public override string SpellBindingKey => nameof(SummonAnimalTarotSpell);
    public override string? RealmBindingKey => nameof(TarotRealm);
    public override string[]? CastSpellScriptBindingKeys => new string[] { nameof(Animal1xPet3In5SummonWeightedRandom) };
}