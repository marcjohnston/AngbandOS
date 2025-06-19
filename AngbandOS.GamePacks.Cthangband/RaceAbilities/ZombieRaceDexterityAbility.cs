namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ZombieRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 1;
}