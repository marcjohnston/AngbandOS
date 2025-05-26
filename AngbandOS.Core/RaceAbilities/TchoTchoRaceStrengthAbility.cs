namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private TchoTchoRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}