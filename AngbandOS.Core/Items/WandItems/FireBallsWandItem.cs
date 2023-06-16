namespace AngbandOS.Core.Items;

[Serializable]
internal class FireBallsWandItem : WandItem
{
    public FireBallsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FireBallsWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(4) + 2;
    }
}