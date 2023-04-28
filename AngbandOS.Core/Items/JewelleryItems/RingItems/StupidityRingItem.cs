namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StupidityRingItem : RingItem
    {
        public StupidityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<RingStupidity>()) { }
        protected override void ApplyMagic(int level, int power)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
        }
    }
}