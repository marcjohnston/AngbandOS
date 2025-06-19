namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class HalfOgreRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.HalfOgreRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -1;
}