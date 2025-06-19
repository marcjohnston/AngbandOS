namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GreatOneRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GreatOneRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 3;
}