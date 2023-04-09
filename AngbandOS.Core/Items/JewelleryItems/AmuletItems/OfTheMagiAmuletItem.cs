namespace AngbandOS.Core.Items
{
[Serializable]
    internal class OfTheMagiAmuletItem : AmuletItem
    {
        public OfTheMagiAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletOfTheMagi>()) { }
        public override bool FreeAct => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool Search => true;
        public override bool SeeInvis => true;
    }
}