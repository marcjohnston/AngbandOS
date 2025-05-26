namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private ImpRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}