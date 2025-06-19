namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GolemRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GolemRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -5;
}