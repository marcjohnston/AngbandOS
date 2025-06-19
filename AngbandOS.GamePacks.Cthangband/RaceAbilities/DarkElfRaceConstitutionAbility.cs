namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DarkElfRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => -2;
}