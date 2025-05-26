namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private KlackonRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}