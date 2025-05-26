namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ZombieRaceStrengthAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(StrengthAbility);
    private ZombieRaceStrengthAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 2;
}