namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class CyclopsRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(CyclopsRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private CyclopsRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}