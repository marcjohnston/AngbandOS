namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class TchoTchoRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(TchoTchoRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private TchoTchoRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}