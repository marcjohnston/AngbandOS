namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfGiantRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -3;
}