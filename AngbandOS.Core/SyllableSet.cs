// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

internal abstract class SyllableSet : IGetKey
{
    protected readonly Game Game;
    protected SyllableSet(Game game)
    {
        Game = game;
    }

    public abstract string[] BeginningSyllables { get; }
    public abstract string[] MiddleSyllables { get; }
    public abstract string[] EndingSyllables { get; }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;

    public void Bind() { }

    public string ToJson()
    {
        return "";
    }

    public string GenerateName()
    {
        string name = "";
        do
        {
            name = BeginningSyllables[Game.RandomLessThan(BeginningSyllables.Length)];
            name += MiddleSyllables[Game.RandomLessThan(MiddleSyllables.Length)];
            name += EndingSyllables[Game.RandomLessThan(EndingSyllables.Length)];
        } while (name.Length > 12);

        return name;
    }
}
