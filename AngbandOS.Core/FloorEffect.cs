// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class FloorEffect : IGetKey
{
    protected readonly Game Game;

    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    protected FloorEffect(Game game)
    {
        Game = game;
    }

    public abstract IsNoticedEnum Apply(int x, int y);
}
