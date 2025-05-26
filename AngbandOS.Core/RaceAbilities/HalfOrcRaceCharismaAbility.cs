namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOrcRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOrcRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfOrcRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}