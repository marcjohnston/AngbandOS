namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private GreatOneRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}