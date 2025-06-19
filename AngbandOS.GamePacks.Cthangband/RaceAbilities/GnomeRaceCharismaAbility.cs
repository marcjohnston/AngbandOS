namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GnomeRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GnomeRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -2;
}