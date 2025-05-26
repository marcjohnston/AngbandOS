namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class HalfTrollRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(HalfTrollRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private HalfTrollRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}