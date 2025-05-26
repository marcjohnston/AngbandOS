namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private KoboldRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}