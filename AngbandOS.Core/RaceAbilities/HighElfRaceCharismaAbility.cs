namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HighElfRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HighElfRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 5;
}