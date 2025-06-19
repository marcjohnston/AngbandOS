namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GreatOneRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GreatOneRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 1;
}