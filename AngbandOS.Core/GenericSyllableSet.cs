// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericSyllableSet : SyllableSet
{
    private GenericSyllableSet(Game game) : base(game) { }
    public GenericSyllableSet(Game game, SyllableSetGameConfiguration syllableSetGameConfiguration) : base(game)
    {
        Key = syllableSetGameConfiguration.Key ?? syllableSetGameConfiguration.GetType().Name;
        BeginningSyllables = syllableSetGameConfiguration.BeginningSyllables;
        MiddleSyllables = syllableSetGameConfiguration.MiddleSyllables;
        EndingSyllables = syllableSetGameConfiguration.EndingSyllables;
    }

    public override string Key { get; }
    public override string[] BeginningSyllables { get; }
    public override string[] MiddleSyllables { get; }
    public override string[] EndingSyllables { get; }
}
