namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ElfRaceIntelligenceAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ElfRace);
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    private ElfRaceIntelligenceAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}