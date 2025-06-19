namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOrcRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOrcRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 2;
}