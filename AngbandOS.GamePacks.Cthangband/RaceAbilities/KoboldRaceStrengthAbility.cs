namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KoboldRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 1;
}