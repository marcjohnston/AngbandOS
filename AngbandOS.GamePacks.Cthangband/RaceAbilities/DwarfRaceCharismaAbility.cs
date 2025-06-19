namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class DwarfRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.DwarfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -3;
}