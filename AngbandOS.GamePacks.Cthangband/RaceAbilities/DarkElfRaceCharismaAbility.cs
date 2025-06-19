namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DarkElfRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DarkElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 1;
}