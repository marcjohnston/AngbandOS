namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HumanRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HumanRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private HumanRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}