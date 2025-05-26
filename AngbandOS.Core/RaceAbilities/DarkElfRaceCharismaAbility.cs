namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private DarkElfRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}