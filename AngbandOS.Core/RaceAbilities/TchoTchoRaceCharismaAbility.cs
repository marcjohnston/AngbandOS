namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private TchoTchoRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}