namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GreatOneRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GreatOneRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 2;
}