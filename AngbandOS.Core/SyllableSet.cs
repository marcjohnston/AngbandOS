// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Xml.Linq;

namespace AngbandOS.Core;

[Serializable]
internal class SyllableSet : IGetKey, IToJson
{
    protected readonly Game Game;
    public SyllableSet(Game game, SyllableSetGameConfiguration syllableSetGameConfiguration)
    {
        Game = game;
        Key = syllableSetGameConfiguration.Key ?? syllableSetGameConfiguration.GetType().Name;
        BeginningSyllables = syllableSetGameConfiguration.BeginningSyllables;
        MiddleSyllables = syllableSetGameConfiguration.MiddleSyllables;
        EndingSyllables = syllableSetGameConfiguration.EndingSyllables;
    }

    public virtual string[] BeginningSyllables { get; }
    public virtual string[] MiddleSyllables { get; }
    public virtual string[] EndingSyllables { get; }
    public virtual string Key { get; }

    public string GetKey => Key;

    public void Bind() { }

    public string ToJson()
    {
        SyllableSetGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            BeginningSyllables = BeginningSyllables,
            MiddleSyllables = MiddleSyllables,
            EndingSyllables = EndingSyllables,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
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
