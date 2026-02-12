namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfGiantRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 3;
}
