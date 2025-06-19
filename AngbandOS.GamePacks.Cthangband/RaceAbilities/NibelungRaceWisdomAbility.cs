namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class NibelungRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.NibelungRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 2;
}