namespace AngbandOS.Core.Items;

[Serializable]
internal class CloneMonsterWandItem : WandItem
{
    public CloneMonsterWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<CloneMonsterWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
    }
}