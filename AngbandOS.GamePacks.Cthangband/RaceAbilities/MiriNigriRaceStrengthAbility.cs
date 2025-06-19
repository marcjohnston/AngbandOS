namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MiriNigriRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MiriNigriRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 2;
}