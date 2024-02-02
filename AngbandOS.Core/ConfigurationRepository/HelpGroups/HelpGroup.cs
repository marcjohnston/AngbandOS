// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.HelpGroups;

[Serializable]
internal abstract class HelpGroup : IGetKey<string>, IToJson
{
    protected SaveGame SaveGame { get; }
    protected HelpGroup(SaveGame saveGame) 
    {
        SaveGame = saveGame;
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public string ToJson()
    {
        HelpGroupDefinition helpGroupDefinition = new()
        {
            Key = Key,
            Title = Title,
            SortIndex= SortIndex,
        };
        return JsonSerializer.Serialize<HelpGroupDefinition>(helpGroupDefinition);
    }

    public abstract string Title { get; }
    public abstract int SortIndex { get; }
}
