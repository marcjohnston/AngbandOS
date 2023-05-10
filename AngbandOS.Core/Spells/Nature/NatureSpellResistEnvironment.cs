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
    internal class NatureSpellResistEnvironment : Spell
    {
        private NatureSpellResistEnvironment(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            saveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            saveGame.Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            saveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        }

        public override string Name => "Resist Environment";
        
        protected override string Comment(Player player)
        {
            return "dur 20+d20";
        }
    }
}