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
    internal class ChaosSpellChainLightning : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            for (int dir = 0; dir <= 9; dir++)
            {
                saveGame.FireBeam(new ElecProjectile(saveGame), dir,
                    Program.Rng.DiceRoll(5 + (saveGame.Player.Level / 10), 8));
            }
        }

        public override string Name => "Chain Lightning";
        
        protected override string Comment(Player player)
        {
            return $"dam {5 + (player.Level / 10)}d8";
        }
    }
}