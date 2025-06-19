namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOrcRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -4;
}