namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HalfTrollRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus =>-6 ;
}