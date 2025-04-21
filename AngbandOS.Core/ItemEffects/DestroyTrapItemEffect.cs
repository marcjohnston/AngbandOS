// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemEffects;

[Serializable]
internal class DestroyTrapItemEffect : ItemEffect
{
    private DestroyTrapItemEffect(Game game) : base(game) { } // This object is a singleton.

    public override bool Apply(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        foreach (Item oPtr in cPtr.Items)
        {
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
        }
        return obvious;
    }
}
