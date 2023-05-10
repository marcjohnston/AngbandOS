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
    internal class NatureSpellCallSunlight : Spell
    {
        private NatureSpellCallSunlight(SaveGame saveGame) : base(saveGame) { }
        public override void Cast(SaveGame saveGame)
        {
            saveGame.FireBall(new LightProjectile(saveGame), 0, 150, 8);
            saveGame.Level.WizLight();
            if (!saveGame.Player.Race.IsBurnedBySunlight || saveGame.Player.HasLightResistance)
            {
                return;
            }
            saveGame.MsgPrint("The sunlight scorches your flesh!");
            saveGame.Player.TakeHit(50, "sunlight");
        }

        public override string Name => "Whirlpool";
        
        protected override string Comment(Player player)
        {
            return "dam 150";
        }
    }
}