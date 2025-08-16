// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class ItemEffect : IGetKey
{
    protected readonly Game Game;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind()
    {
    }
    protected ItemEffect(Game game)
    {
        Game = game;
    }

    protected virtual bool ApplyItem(Item item, int who, int x, int y)
    {
        return false;
    }

    public virtual bool Apply(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        foreach (Item oPtr in cPtr.Items.ToArray()) // Prevent collection modified error
        {
            if (ApplyItem(oPtr, who, x, y))
            {
                obvious = true;
            }
        }
        return obvious;
    }
}
