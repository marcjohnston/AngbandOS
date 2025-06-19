namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampireRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 2;
}