namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOrcRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 0;
}