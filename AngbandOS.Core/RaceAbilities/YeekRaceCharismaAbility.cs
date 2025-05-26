namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private YeekRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -7;
}