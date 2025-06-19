namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class KoboldRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.KoboldRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => -4;
}