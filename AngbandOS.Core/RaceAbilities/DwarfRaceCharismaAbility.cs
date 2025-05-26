namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class DwarfRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(DwarfRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private DwarfRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -3;
}