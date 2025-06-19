namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MiriNigriRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MiriNigriRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 2;
}