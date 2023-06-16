namespace AngbandOS.Core.Items;

[Serializable]
internal class MagicMissileWandItem : WandItem
{
    public MagicMissileWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<MagicMissileWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
    }
}