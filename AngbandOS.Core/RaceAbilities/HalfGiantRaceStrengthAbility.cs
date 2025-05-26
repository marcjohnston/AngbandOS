namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfGiantRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfGiantRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfGiantRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}