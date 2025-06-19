namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighElfRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HighElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 5;
}