namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfElfRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfElfRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private HalfElfRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}