namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private TchoTchoRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}