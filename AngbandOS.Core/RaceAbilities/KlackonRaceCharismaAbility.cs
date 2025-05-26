namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KlackonRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KlackonRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private KlackonRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}