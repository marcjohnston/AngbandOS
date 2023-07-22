// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.SpellResistantDetections;

internal class FireSpellResistantDetection : SpellResistantDetection
{
    public override void Learn(SaveGame saveGame, Monster monster)
    {
        if (saveGame.HasFireResistance)
        {
            monster.SmResFire = true;
        }
        if (saveGame.TimedFireResistance.TurnsRemaining != 0)
        {
            monster.SmOppFire = true;
        }
        if (saveGame.HasFireImmunity)
        {
            monster.SmImmFire = true;
        }
    }
}
