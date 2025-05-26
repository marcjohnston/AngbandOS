namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private GnomeRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -2;
}