namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HighElfRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HighElfRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 1;
}