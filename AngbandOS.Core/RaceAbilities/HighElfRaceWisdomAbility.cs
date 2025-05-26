namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HighElfRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HighElfRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}