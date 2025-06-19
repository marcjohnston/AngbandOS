namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class YeekRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.YeekRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -7;
}