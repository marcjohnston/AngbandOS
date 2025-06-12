// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]

internal class RenderMessageScript : IGetKey, IUniversalScript
{
    protected readonly Game Game;
    public RenderMessageScript(Game game, RenderMessageScriptGameConfiguration renderMessageScriptGameConfiguration)
    {
        Game = game;
        Key = renderMessageScriptGameConfiguration.Key ?? renderMessageScriptGameConfiguration.GetType().Name;
        Message = renderMessageScriptGameConfiguration.Message;
        UsesItem = renderMessageScriptGameConfiguration.UsesItem;
        IdentifiesItem = renderMessageScriptGameConfiguration.IdentifiesItem;
    }

    public virtual bool UsesItem { get; } = false;
    public virtual bool IdentifiesItem { get; } = false;

    public virtual string Message { get; }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return new UsedResult(UsesItem);
    }

    public IdentifiedResult ExecuteAimWandScript(int dir)
    {
        ExecuteScript();
        return new IdentifiedResult(IdentifiesItem);
    }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
    }

    public void ExecuteScript()
    {
        Game.MsgPrint(Message);
    }

    /// <summary>
    /// Renders the message and returns false for both the identified and used results.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="dir"></param>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        ExecuteScript();
        return new IdentifiedAndUsedResult(IdentifiesItem, UsesItem);
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

    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        ExecuteScript();
        return new IdentifiedResult(IdentifiesItem);
    }

    public virtual string Key { get; }

    /// <summary>
    /// Returns information about this message, or blank if there is no detailed information.  Returns blank, by default.  Returns blank, by default.
    /// </summary>
    public virtual string LearnedDetails => "";

    public string GetKey => Key;
}

