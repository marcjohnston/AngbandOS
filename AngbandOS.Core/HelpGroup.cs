// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class HelpGroup : IGetKey
{
    protected readonly Game Game;
    public HelpGroup(Game game, HelpGroupGameConfiguration helpGroupGameConfiguration)
    {
        Game = game;
        Key = helpGroupGameConfiguration.Key ?? helpGroupGameConfiguration.GetType().Name;
        SortIndex = helpGroupGameConfiguration.SortIndex;
        Title = helpGroupGameConfiguration.Title;
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public virtual void Bind() { }

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

    public virtual string Title { get; }
    public virtual int SortIndex { get; }
}
