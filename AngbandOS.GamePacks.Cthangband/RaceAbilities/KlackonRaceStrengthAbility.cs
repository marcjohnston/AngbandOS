namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KlackonRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KlackonRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 2;
}