namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DarkElfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DarkElfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private DarkElfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}