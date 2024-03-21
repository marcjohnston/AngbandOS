// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

//namespace AngbandOS
//{
//    [Serializable]
//    internal class HighScore
//    {
//        public readonly string How;
//        public readonly int Pclass;
//        public readonly Race Prace;
//        public readonly int Pts;
//        public readonly string When;
//        public readonly string Where;
//        public readonly string Who;
//        public bool Hilight;
//        public int Index;
//        public bool Living;

//        public HighScore(Game game)
//        {
//            Pts = game.GetScore(game);
//            Prace = game.Race;
//            Pclass = game.ProfessionIndex;
//            if (game.IsDead)
//            {
//                When = DateTime.Now.ToString("dd-MMM-yyyy");
//                How = game.DiedFrom;
//            }
//            else
//            {
//                Living = true;
//                When = "TODAY";
//                How = "nobody (yet!)";
//            }
//            Who = $"{game.Name.Trim()}{game.Generation.ToRoman(true)} the level {game.Level} {game.Race.Title} {Profession.ClassSubName(game.ProfessionIndex, game.Realm1)}";
//            if (game.CurrentDepth > 0)
//            {
//                Where = $"on level {game.CurrentDepth} of {game.CurDungeon.Name}";
//            }
//            else
//            {
//                Where = "in the wilderness";
//                foreach (Town t in game.Towns)
//                {
//                    if (game.WildernessX == t.X && game.WildernessY == t.Y)
//                    {
//                        Where = $"in {t.Name}";
//                    }
//                }
//            }
//        }

//        private HighScore()
//        {
//        }
//    }
//}