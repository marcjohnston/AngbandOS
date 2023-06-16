namespace AngbandOS.Core.Items;

[Serializable]
internal class DragonsFrostWandItem : WandItem
{
    public DragonsFrostWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<DragonsFrostWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
    }
}