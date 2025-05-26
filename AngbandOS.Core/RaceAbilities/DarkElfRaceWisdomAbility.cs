namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private DarkElfRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}