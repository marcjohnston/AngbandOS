namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class SpikeItem : Item
{
    public SpikeItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);
    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (cost <= 5)
        {
            return MassRoll(5, 5);
        }
        if (cost <= 50)
        {
            return MassRoll(5, 5);
        }
        if (cost <= 500)
        {
            return MassRoll(5, 5);
        }
        return 0;
    }
}