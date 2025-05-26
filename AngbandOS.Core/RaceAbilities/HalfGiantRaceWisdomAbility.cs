namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private HalfGiantRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}