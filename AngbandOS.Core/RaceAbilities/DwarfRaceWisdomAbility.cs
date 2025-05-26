namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private DwarfRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}