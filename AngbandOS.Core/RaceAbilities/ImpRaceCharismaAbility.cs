namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private ImpRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}