﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemEffects;

[Serializable]
internal class HolyFireItemEffect : ItemEffect
{
    private HolyFireItemEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            if (oPtr.StackCount > 1)
            {
                plural = true;
            }

            if (oPtr.EffectiveItemPropertySet.IsCursed)
            {
                doKill = true;
                noteKill = plural ? " are destroyed!" : " is destroyed!";
            }
            if (doKill)
            {
                if (oPtr.WasNoticed)
                {
                    obvious = true;
                    oName = oPtr.GetDescription(false);
                }
                if (oPtr.IsArtifact)
                {
                    if (oPtr.WasNoticed)
                    {
                        string s = plural ? "are" : "is";
                        Game.MsgPrint($"The {oName} {s} unaffected!");
                    }
                }
                else
                {
                    if (oPtr.WasNoticed && string.IsNullOrEmpty(noteKill))
                    {
                        Game.MsgPrint($"The {oName}{noteKill}");
                    }
                    bool isPotion = oPtr.QuaffTuple != null;
                    Game.DeleteObject(oPtr);
                    if (isPotion)
                    {
                        oPtr.Smash(who, y, x);
                    }
                    Game.ConsoleView.RefreshMapLocation(y, x);
                }
            }
        }
        return obvious;
    }
}
