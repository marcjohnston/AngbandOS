namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class SpectreRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(SpectreRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private SpectreRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -6;
}