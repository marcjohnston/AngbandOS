namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOgreRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -1;
}