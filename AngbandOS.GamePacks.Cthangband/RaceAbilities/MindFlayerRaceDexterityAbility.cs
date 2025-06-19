namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
internal class MindFlayerRaceDexterityAbility : RaceAbilityGameConfiguration
{
    public override string RaceBindingKey => nameof(RacesEnum.MindFlayerRace);
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override int Bonus => 0;
}