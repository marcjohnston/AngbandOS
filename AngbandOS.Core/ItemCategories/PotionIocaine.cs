namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PotionIocaine : PotionItemClass
    {
        private PotionIocaine(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Iocaine";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Dd => 20;
        public override int Ds => 20;
        public override string FriendlyName => "Iocaine";
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override int? SubCategory => (int)PotionType.Death;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            // Iocaine simply does 5000 damage
            saveGame.MsgPrint("A feeling of Death flows through your body.");
            saveGame.Player.TakeHit(5000, "a potion of Death");
            return true;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 1, y, x, 0, new DeathRayProjectile(saveGame), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
        public override Item CreateItem(SaveGame saveGame) => new IocainePotionItem(saveGame);
    }
}
