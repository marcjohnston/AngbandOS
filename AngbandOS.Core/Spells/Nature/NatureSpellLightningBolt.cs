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
    internal class NatureSpellLightningBolt : Spell
    {
        private NatureSpellLightningBolt(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            int beam;
            switch (saveGame.Player.BaseCharacterClass.ID)
            {
                case CharacterClass.Mage:
                    beam = saveGame.Player.Level;
                    break;

                case CharacterClass.HighMage:
                    beam = saveGame.Player.Level + 10;
                    break;

                default:
                    beam = saveGame.Player.Level / 2;
                    break;
            }
            if (!saveGame.GetDirectionWithAim(out int dir))
            {
                return;
            }
            saveGame.FireBoltOrBeam(beam - 10, new ElecProjectile(saveGame), dir,
                Program.Rng.DiceRoll(3 + ((saveGame.Player.Level - 5) / 4), 8));
        }

        public override string Name => "Lightning Bolt";
        
        protected override string Comment(Player player)
        {
            return $"dam {3 + ((player.Level - 5) / 4)}d8";
        }
    }
}