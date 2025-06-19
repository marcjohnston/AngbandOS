namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindFlayerRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 4;
}