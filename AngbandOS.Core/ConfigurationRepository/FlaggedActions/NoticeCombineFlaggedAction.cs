// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class NoticeCombineFlaggedAction : FlaggedAction
{
    private NoticeCombineFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void Execute()
    {
        bool flag = false;
        for (int i = InventorySlot.PackCount; i > 0; i--)
        {
            Item? oPtr = SaveGame.GetInventoryItem(i);
            if (oPtr != null)
            {
                for (int j = 0; j < i; j++)
                {
                    Item jPtr = SaveGame.GetInventoryItem(j);
                    if (jPtr != null)
                    {
                        if (jPtr.CanAbsorb(oPtr))
                        {
                            flag = true;
                            jPtr.Absorb(oPtr);
                            SaveGame._invenCnt--;
                            int k;
                            for (k = i; k < InventorySlot.PackCount; k++)
                            {
                                SaveGame.SetInventoryItem(k, SaveGame.GetInventoryItem(k + 1));
                            }
                            SaveGame.SetInventoryItem(k, null);
                            break;
                        }
                    }
                }
            }
        }
        if (flag)
        {
            SaveGame.MsgPrint("You combine some items in your pack.");
        }
    }
}
