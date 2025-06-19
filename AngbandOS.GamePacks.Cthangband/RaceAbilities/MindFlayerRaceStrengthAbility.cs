namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindFlayerRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => -3;
}