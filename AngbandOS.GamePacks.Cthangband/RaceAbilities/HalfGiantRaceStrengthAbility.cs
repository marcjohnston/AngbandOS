namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfGiantRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 4;
}