﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class NoticeCombineFlaggedAction : FlaggedAction
{
    private NoticeCombineFlaggedAction(Game game) : base(game) { }

    protected override void Execute()
    {
        bool flag = false;
        for (int i = InventorySlotEnum.PackCount; i > 0; i--)
        {
            Item? oPtr = Game.GetInventoryItem(i);
            if (oPtr != null)
            {
                for (int j = 0; j < i; j++)
                {
                    Item jPtr = Game.GetInventoryItem(j);
                    if (jPtr != null)
                    {
                        if (jPtr.CanAbsorb(oPtr))
                        {
                            flag = true;
                            jPtr.Absorb(oPtr);
                            Game._invenCnt--;
                            int k;
                            for (k = i; k < InventorySlotEnum.PackCount; k++)
                            {
                                Game.SetInventoryItem(k, Game.GetInventoryItem(k + 1));
                            }
                            Game.SetInventoryItem(k, null);
                            break;
                        }
                    }
                }
            }
        }
        if (flag)
        {
            Game.MsgPrint("You combine some items in your pack.");
        }
    }
}
