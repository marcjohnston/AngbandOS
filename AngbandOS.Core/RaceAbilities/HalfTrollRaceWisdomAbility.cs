namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfTrollRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}