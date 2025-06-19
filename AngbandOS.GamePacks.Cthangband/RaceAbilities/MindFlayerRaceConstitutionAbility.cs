namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindFlayerRaceConstitutionAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override int Bonus => -2;
}