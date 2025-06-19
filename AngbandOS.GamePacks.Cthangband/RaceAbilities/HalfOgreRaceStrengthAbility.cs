namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOgreRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 3;
}