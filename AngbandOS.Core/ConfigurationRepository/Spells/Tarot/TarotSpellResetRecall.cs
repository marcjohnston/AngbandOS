﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Tarot;

[Serializable]
internal class TarotSpellResetRecall : Spell
{
    private TarotSpellResetRecall(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        string ppp = $"Reset to which level (1-{SaveGame.CurDungeon.RecallLevel}): ";
        string def = $"{Math.Max(SaveGame.CurrentDepth, 1)}";
        if (!SaveGame.GetString(ppp, out string tmpVal, def, 10))
        {
            return;
        }
        if (!int.TryParse(tmpVal, out int dummy))
        {
            dummy = 1;
        }
        if (dummy < 1)
        {
            dummy = 1;
        }
        if (dummy > SaveGame.CurDungeon.RecallLevel)
        {
            dummy = SaveGame.CurDungeon.RecallLevel;
        }
        SaveGame.MsgPrint($"Recall depth set to level {dummy}.");
    }

    public override string Name => "Reset Recall";
    
}