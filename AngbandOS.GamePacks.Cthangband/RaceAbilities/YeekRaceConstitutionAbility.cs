namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class YeekRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.YeekRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => -2;
}