namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTitanRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTitanRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 5;
}