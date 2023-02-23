// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents
{
    [Serializable]
    internal class TalentMindWave : Talent
    {
        public override void Initialise(int characterClass)
        {
            Name = "Mind Wave";
            Level = 18;
            ManaCost = 10;
            BaseFailure = 45;
        }

        public override void Use(SaveGame saveGame)
        {
            saveGame.MsgPrint("Mind-warping forces emanate from your brain!");
            if (saveGame.Player.Level < 25)
            {
                saveGame.Project(0, 2 + (saveGame.Player.Level / 10), saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Player.Level * 3 / 2,
                    new PsiProjectile(saveGame), ProjectionFlag.ProjectKill);
            }
            else
            {
                saveGame.MindblastMonsters(saveGame.Player.Level * (((saveGame.Player.Level - 5) / 10) + 1));
            }
        }

        protected override string Comment(Player player)
        {
            return player.Level < 25 ? $"dam {player.Level * 3 / 2}" : $"dam {player.Level * (((player.Level - 5) / 10) + 1)}";
        }
    }
}