namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class KoboldRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(KoboldRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private KoboldRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}