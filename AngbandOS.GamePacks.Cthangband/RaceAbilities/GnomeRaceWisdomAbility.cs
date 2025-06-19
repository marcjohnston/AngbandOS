namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GnomeRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GnomeRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 0;
}