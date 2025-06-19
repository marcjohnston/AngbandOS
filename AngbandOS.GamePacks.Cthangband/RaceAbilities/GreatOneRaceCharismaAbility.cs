namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class GreatOneRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.GreatOneRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 2;
}