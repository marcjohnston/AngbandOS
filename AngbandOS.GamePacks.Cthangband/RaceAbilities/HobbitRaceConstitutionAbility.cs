namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HobbitRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HobbitRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 2;
}