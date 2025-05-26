namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MiriNigriRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private MiriNigriRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}