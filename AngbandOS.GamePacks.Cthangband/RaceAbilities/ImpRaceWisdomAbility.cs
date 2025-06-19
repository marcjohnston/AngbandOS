namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ImpRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ImpRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => -1;
}