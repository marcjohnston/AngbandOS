namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTrollRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 2;
}