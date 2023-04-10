namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SpikeItem : Item
    {
        public SpikeItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);
    }
}