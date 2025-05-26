namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private SpectreRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}