namespace AngbandOS.Core.Items;

[Serializable]
internal class SlowMonsterWandItem : WandItem
{
    public SlowMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<SlowMonsterWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
    }
}