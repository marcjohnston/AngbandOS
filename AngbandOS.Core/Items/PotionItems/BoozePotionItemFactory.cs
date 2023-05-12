namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class BoozePotionItemFactory : PotionItemFactory
    {
        private BoozePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '!';
        public override string Name => "Booze";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "Booze";
        public override int Pval => 50;
        public override int? SubCategory => (int)PotionType.Confusion;
        public override int Weight => 4;
        public override bool Quaff(SaveGame saveGame)
        {
            bool identified = false;

            // Confusion makes you confused and possibly other effects
            if (!(saveGame.Player.HasConfusionResistance || saveGame.Player.HasChaosResistance))
            {
                if (saveGame.Player.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(20) + 15))
                {
                    identified = true;
                }
                // 50% chance of having hallucinations
                if (Program.Rng.DieRoll(2) == 1)
                {
                    if (saveGame.Player.TimedHallucinations.AddTimer(Program.Rng.RandomLessThan(150) + 150))
                    {
                        identified = true;
                    }
                }
                // 1 in 13 chance of blacking out and waking up somewhere else
                if (Program.Rng.DieRoll(13) == 1)
                {
                    identified = true;
                    // 1 in 3 chance of losing your memories after blacking out
                    if (Program.Rng.DieRoll(3) == 1)
                    {
                        saveGame.LoseAllInfo();
                    }
                    else
                    {
                        saveGame.Level.WizDark();
                    }
                    saveGame.TeleportPlayer(100);
                    saveGame.Level.WizDark();
                    saveGame.MsgPrint("You wake up somewhere with a sore head...");
                    saveGame.MsgPrint("You can't remember a thing, or how you got here!");
                }
            }
            return identified;
        }

        public override bool Smash(SaveGame saveGame, int who, int y, int x)
        {
            saveGame.Project(who, 2, y, x, 0, saveGame.SingletonRepository.Projectiles.Get<OldConfProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return true;
        }
        public override Item CreateItem() => new BoozePotionItem(SaveGame);
    }
}
