namespace AngbandOS.Core.Items;

[Serializable]
internal class IlluminationRodItem : RodItem
{
    public IlluminationRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RodIllumination>()) { }
}