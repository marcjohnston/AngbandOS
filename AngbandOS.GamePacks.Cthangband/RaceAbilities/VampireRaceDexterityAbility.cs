namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class VampireRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.VampireRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => -1;
}