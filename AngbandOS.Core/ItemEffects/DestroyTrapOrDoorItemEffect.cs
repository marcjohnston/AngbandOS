// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemEffects;

[Serializable]
internal class DestroyTrapOrDoorItemEffect : ItemEffect
{
    private DestroyTrapOrDoorItemEffect(Game game) : base(game) { } // This object is a singleton.

    protected override bool ApplyItem(Item oPtr, int who, int x, int y)
    {
        bool obvious = false;
        if (oPtr.IsContainer)
        {
            if (!oPtr.ContainerIsOpen && oPtr.ContainerTraps != null)
            {
                oPtr.ContainerTraps = null;
                oPtr.BecomeKnown();
                if (oPtr.WasNoticed)
                {
                    Game.MsgPrint("Click!");
                    obvious = true;
                }
            }
        }
        return obvious;
    }
}
