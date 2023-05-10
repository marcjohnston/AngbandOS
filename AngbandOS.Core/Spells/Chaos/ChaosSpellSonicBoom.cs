// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos
{
    [Serializable]
    internal class ChaosSpellSonicBoom : Spell
    {
        private ChaosSpellSonicBoom(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Project(0, 2 + (saveGame.Player.Level / 10), saveGame.Player.MapY, saveGame.Player.MapX, 45 + saveGame.Player.Level,
                new SoundProjectile(saveGame), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
        }

        public override string Name => "Sonic Boom";
        
        protected override string Comment(Player player)
        {
            return $"dam {45 + player.Level}";
        }
    }
}