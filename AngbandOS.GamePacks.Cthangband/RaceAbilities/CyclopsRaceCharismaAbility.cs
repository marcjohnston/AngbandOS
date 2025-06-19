namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CyclopsRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -6;
}