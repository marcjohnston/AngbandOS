namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GnomeRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GnomeRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => -1;
}