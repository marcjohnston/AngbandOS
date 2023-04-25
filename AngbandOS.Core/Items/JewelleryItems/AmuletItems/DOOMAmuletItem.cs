namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DOOMAmuletItem : AmuletItem
    {
        public DOOMAmuletItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<AmuletDOOM>()) { }

        public override void ApplyMagic(int level, int power)
        {
            IdentBroken = true;
            IdentCursed = true;
            TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
            BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
        }
    }
}