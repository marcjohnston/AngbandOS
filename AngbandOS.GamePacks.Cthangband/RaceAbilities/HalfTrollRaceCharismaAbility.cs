namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTrollRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus =>-6 ;
}