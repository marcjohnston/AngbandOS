// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature
{
    [Serializable]
    internal class NatureSpellNaturesWrath : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            saveGame.DispelMonsters(saveGame.Player.Level * 4);
            saveGame.Earthquake(saveGame.Player.MapY, saveGame.Player.MapX, 20 + (saveGame.Player.Level / 2));
            saveGame.Project(0, 1 + (saveGame.Player.Level / 12), saveGame.Player.MapY, saveGame.Player.MapX, 100 + saveGame.Player.Level,
                new DisintegrateProjectile(saveGame), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
        }

        public override string Name => "Nature's Wrath";
        
        protected override string Comment(Player player)
        {
            return $"dam {4 * player.Level}+{100 + player.Level}";
        }
    }
}