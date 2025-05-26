namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfOgreRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfOgreRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfOgreRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}