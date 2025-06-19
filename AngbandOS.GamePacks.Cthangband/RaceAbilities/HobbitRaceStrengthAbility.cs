namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HobbitRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => -2;
}