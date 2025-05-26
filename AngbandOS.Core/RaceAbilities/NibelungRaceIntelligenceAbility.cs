namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class NibelungRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(NibelungRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private NibelungRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}