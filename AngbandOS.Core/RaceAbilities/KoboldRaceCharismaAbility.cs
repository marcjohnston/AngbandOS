namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private KoboldRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -4;
}