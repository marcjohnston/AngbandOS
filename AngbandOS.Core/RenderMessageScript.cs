// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]

internal class RenderMessageScript : UniversalScript, IGetKey
{
    public RenderMessageScript(Game game, RenderMessageScriptGameConfiguration renderMessageScriptGameConfiguration) : base(game)
    {
        Key = renderMessageScriptGameConfiguration.Key ?? renderMessageScriptGameConfiguration.GetType().Name;
        Message = renderMessageScriptGameConfiguration.Message;
        UsesItem = renderMessageScriptGameConfiguration.UsesItem;
        IdentifiesItem = renderMessageScriptGameConfiguration.IdentifiesItem;
    }

    public override bool UsesItem { get; } = false;
    public override bool IdentifiesItem { get; } = false;

    public virtual string Message { get; }

    public override void ExecuteScript()
    {
        Game.MsgPrint(Message);
    }

    public string ToJson()
    {
        RenderMessageScriptGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            Message = Message,
            UsesItem = UsesItem,
            IdentifiesItem = IdentifiesItem
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public void Bind() { }

    public virtual string Key { get; }

    public string GetKey => Key;
}

