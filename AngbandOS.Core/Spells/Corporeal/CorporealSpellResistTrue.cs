// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Corporeal
{
    [Serializable]
    internal class CorporealSpellResistTrue : Spell
    {
        private CorporealSpellResistTrue(SaveGame saveGame) : base(saveGame) { }
        public override void Cast()
        {
            SaveGame.Player.TimedAcidResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            SaveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            SaveGame.Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            SaveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
            SaveGame.Player.TimedPoisonResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        }

        public override string Name => "Resist True";
        
        protected override string? Info()
        {
            return "dur 20+d20";
        }
    }
}