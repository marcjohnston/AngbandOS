﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.SpellResistantDetections;

[Serializable]
internal class ColdSpellResistantDetection : SpellResistantDetection
{
    private ColdSpellResistantDetection(Game game) : base(game) { }
    public override void Learn(Monster monster)
    {
        if (Game.HasColdResistance)
        {
            monster.SmResCold = true;
        }
        if (Game.ColdResistanceTimer.Value != 0)
        {
            monster.SmOppCold = true;
        }
        if (Game.HasColdImmunity)
        {
            monster.SmImmCold = true;
        }
    }
}
