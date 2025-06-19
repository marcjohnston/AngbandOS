namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DraconianRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DraconianRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 1;
}