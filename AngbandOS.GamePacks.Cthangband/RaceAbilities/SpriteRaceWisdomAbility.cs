namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class SpriteRaceWisdomAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.SpriteRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override int Bonus => 3;
}