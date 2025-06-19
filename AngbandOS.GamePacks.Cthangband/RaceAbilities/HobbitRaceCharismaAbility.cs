namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HobbitRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 1;
}