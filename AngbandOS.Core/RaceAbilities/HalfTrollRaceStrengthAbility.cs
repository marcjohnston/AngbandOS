namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfTrollRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}