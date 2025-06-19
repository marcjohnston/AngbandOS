namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTrollRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTrollRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 4;
}