namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class CyclopsRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(CyclopsRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private CyclopsRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}