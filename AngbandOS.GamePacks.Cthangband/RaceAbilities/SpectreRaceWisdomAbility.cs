namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpectreRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpectreRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 4;
}