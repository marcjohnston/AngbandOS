namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private KoboldRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}