namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private TchoTchoRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}