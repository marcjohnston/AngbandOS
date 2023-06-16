namespace AngbandOS.Core.Items;

[Serializable]
internal class FireBoltsWandItem : WandItem
{
    public FireBoltsWandItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<FireBoltsWandItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
    }
}