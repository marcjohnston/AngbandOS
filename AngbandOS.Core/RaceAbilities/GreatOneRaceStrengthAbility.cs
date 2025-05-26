namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private GreatOneRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}