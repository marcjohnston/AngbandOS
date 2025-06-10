// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Alignment : IGetKey
{
    protected readonly Game Game;
    protected Alignment(Game game)
    {
        Game = game;
    }

    public string GetKey => GetType().Name;

    public abstract string[] Align(string[] lines, int mininumHeight);

    public virtual void Bind() { }

    public string ToJson()
    {
        return "";
    }
}
