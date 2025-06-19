namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MiriNigriRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MiriNigriRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -1;
}