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
        private NatureSpellNaturesWrath(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            SaveGame.DispelMonsters(SaveGame.Player.Level * 4);
            SaveGame.Earthquake(SaveGame.Player.MapY, SaveGame.Player.MapX, 20 + (SaveGame.Player.Level / 2));
            SaveGame.Project(0, 1 + (SaveGame.Player.Level / 12), SaveGame.Player.MapY, SaveGame.Player.MapX, 100 + SaveGame.Player.Level,
                SaveGame.SingletonRepository.Projectiles.Get<DisintegrateProjectile>(), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectItem);
        }

        public override string Name => "Nature's Wrath";
        
        protected override string? Info()
        {
            return $"dam {4 * SaveGame.Player.Level}+{100 + SaveGame.Player.Level}";
        }
    }
}