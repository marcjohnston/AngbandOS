namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KlackonRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -1;
}