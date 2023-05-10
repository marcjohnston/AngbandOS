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
    internal class DeathSpellOrbOfEntropy : Spell
    {
        public override void Cast(SaveGame saveGame)
        {
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBall(new OldDrainProjectile(saveGame), dir,
                Program.Rng.DiceRoll(3, 6) + saveGame.Player.Level + (saveGame.Player.Level /
                (saveGame.Player.BaseCharacterClass.ID == CharacterClass.Mage || saveGame.Player.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4)),
                saveGame.Player.Level < 30 ? 2 : 3);
        }

        public override string Name => "Orb of Entropy";
        
        protected override string Comment(Player player)
        {
            int s = player.Level + (player.Level / (player.BaseCharacterClass.ID == CharacterClass.Mage || player.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4));
            return $"dam 3d6+{s}";
        }
    }
}