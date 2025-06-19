namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NibelungRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => 2;
}