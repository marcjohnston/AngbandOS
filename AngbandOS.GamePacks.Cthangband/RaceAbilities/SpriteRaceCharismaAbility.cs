namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpriteRaceCharismaAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override int Bonus => 2;
}