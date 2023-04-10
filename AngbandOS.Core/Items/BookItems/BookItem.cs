namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BookItem : Item
    {
        public BookItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
            if (cost <= 50)
            {
                return MassRoll(2, 3) + 1;
            }
            if (cost <= 500)
            {
                return MassRoll(1, 3) + 1;
            }
            return 0;
        }

    }
}