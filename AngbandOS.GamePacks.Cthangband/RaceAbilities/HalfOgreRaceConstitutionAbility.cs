namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOgreRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 3;
}