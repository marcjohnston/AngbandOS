// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class HelpGroup : IGetKey, IToJson
{
    private readonly Game Game;
    public HelpGroup(Game game, HelpGroupGameConfiguration helpGroupGameConfiguration)
    {
        Game = game;
        Key = helpGroupGameConfiguration.Key ?? helpGroupGameConfiguration.GetType().Name;
        SortIndex = helpGroupGameConfiguration.SortIndex;
        Title = helpGroupGameConfiguration.Title;
    }

    public string Key { get; }

    public string GetKey => Key;
    public void Bind() { }

    public string ToJson()
    {
        HelpGroupGameConfiguration helpGroupDefinition = new()
        {
            Key = Key,
            Title = Title,
            SortIndex= SortIndex,
        };
        return JsonSerializer.Serialize(helpGroupDefinition, Game.GetJsonSerializerOptions());
    }

    public string Title { get; }
    public int SortIndex { get; }
}
