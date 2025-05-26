namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private KlackonRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}