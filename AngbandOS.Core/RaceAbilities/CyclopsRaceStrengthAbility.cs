namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class CyclopsRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(CyclopsRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private CyclopsRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}