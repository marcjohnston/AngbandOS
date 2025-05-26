namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceWisdomAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(WisdomAbility);
    private GnomeRaceWisdomAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 0;
}