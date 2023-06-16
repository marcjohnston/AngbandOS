namespace AngbandOS.Core.Items;

[Serializable]
internal class WonderWandItem : WandItem
{
    public WonderWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WonderWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
    }
}