namespace AngbandOS.Core.Items;

[Serializable]
internal class FrostBoltsWandItem : WandItem
{
    public FrostBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FrostBoltsWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
    }
}