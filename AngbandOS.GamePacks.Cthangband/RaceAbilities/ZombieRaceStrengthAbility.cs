namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class ZombieRaceStrengthAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.ZombieRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override int Bonus => 2;
}