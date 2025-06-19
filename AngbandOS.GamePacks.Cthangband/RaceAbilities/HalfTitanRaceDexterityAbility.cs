namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfTitanRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfTitanRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -2;
}