namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HobbitRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 1;
}