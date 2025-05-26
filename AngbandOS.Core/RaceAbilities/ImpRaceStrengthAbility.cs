namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ImpRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ImpRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private ImpRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}