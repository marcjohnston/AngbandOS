namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ReflectionAmuletItem : AmuletItem
    {
        public ReflectionAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<AmuletReflection>()) { }
        public override bool EasyKnow => true;
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override bool Reflect => true;
    }
}