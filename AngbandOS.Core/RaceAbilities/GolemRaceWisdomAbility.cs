namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GolemRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GolemRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private GolemRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}