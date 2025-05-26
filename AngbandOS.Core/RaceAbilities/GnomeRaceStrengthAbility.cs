namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class GnomeRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(GnomeRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private GnomeRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -1;
}