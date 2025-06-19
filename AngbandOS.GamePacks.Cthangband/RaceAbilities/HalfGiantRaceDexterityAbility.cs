namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfGiantRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfGiantRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -2;
}