namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GreatOneRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GreatOneRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private GreatOneRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}