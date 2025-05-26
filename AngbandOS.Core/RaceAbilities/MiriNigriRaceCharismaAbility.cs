namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class MiriNigriRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(MiriNigriRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private MiriNigriRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}