namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MiriNigriRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MiriNigriRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -4;
}