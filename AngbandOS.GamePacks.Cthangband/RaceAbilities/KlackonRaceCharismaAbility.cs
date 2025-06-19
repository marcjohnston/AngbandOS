namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KlackonRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -2;
}