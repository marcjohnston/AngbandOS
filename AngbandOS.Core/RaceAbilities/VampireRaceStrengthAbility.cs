namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class VampireRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(VampireRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private VampireRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 3;
}