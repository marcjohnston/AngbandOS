namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ZombieRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private ZombieRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -6;
}