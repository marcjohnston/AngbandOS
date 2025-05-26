namespace AngbandOS.Core.RaceAbilities;

[Serializable]
internal class ZombieRaceDexterityAbility : RaceAbility
{
    public override string RaceBindingKey => nameof(ZombieRace);
    public override string AbilityBindingKey => nameof(DexterityAbility);
    private ZombieRaceDexterityAbility(Game game) : base(game) { } // This object is a singleton
    public override int Bonus => 1;
}