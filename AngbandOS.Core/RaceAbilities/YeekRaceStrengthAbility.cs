namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class YeekRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(YeekRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private YeekRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}