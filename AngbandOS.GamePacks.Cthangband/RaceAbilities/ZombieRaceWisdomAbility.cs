namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ZombieRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -6;
}