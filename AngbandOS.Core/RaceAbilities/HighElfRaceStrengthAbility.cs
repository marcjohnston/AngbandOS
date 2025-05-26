namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HighElfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HighElfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HighElfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}