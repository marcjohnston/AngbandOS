// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PoisonPitScript : Script, IScript, ICastSpellScript
{
    private PoisonPitScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // A pit can be flown over with feather fall
        if (Game.HasFeatherFall)
        {
            Game.MsgPrint("You fly over a spiked pit.");
        }
        else
        {
            Game.MsgPrint("You fall into a spiked pit!");
            // A pit does 2d6 fall damage
            int damage = Game.DiceRoll(2, 6);
            string name = "a pit trap";
            // 50% chance of doing double damage plus bleeding plus poison
            if (Game.RandomLessThan(100) < 50)
            {
                Game.MsgPrint("You are impaled on poisonous spikes!");
                name = "a spiked pit";
                damage *= 2;
                Game.BleedingTimer.AddTimer(Game.DieRoll(damage));
                // Hagarg Ryonis can save us from the poison
                if (Game.HasPoisonResistance || Game.PoisonResistanceTimer.Value != 0)
                {
                    Game.MsgPrint("The poison does not affect you!");
                }
                else if (Game.DieRoll(10) <= Game.SingletonRepository.Get<God>(nameof(HagargRyonisGod)).AdjustedFavour)
                {
                    Game.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else
                {
                    damage *= 2;
                    Game.PoisonTimer.AddTimer(Game.DieRoll(damage));
                }
            }
            Game.TakeHit(damage, name);
        }
    }
}
