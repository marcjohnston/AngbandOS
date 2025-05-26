namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GolemRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GolemRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private GolemRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}