namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ZombieRaceCharismaAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(CharismaAbility);
    private ZombieRaceCharismaAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => -5;
}