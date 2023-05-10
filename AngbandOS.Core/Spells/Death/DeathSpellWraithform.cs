// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death
{
    [Serializable]
    internal class DeathSpellWraithform : Spell
    {
        private DeathSpellWraithform(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            SaveGame.Player.TimedEtherealness.AddTimer(Program.Rng.DieRoll(SaveGame.Player.Level / 2) + (SaveGame.Player.Level / 2));
        }

        public override string Name => "Wraithform";
        
        protected override string? Info()
        {
            return $"dur {SaveGame.Player.Level / 2}+d{SaveGame.Player.Level / 2}";
        }
    }
}