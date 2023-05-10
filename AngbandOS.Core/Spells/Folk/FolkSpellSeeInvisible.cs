// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Folk
{
    [Serializable]
    internal class FolkSpellSeeInvisible : Spell
    {
        private FolkSpellSeeInvisible(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            SaveGame.Player.TimedSeeInvisibility.AddTimer(Program.Rng.DieRoll(24) + 24);
        }

        public override string Name => "See Invisible";
        
        protected override string? Info()
        {
            return "dur 24+d24";
        }
    }
}