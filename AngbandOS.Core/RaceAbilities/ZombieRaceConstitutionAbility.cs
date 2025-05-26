namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ZombieRaceConstitutionAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    private ZombieRaceConstitutionAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 4;
}