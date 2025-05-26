namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTitanRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTitanRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfTitanRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}