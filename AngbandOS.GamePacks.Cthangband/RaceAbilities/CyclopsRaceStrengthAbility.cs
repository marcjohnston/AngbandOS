namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class CyclopsRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.CyclopsRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 4;
}