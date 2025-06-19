namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CyclopsRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -3;
}