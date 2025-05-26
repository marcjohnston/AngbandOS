namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private SpectreRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}