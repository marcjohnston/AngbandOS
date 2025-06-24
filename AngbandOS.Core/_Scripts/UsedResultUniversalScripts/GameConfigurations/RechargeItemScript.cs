// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RechargeItemScript : UsedResultUniversalScript, IGetKey
{
    public RechargeItemScript(Game game, RechargeItemScriptGameConfiguration rechargeItemScriptGameConfiguration) : base(game)
    {
        Key = rechargeItemScriptGameConfiguration.Key ?? rechargeItemScriptGameConfiguration.GetType().Name;
        TurnsExpression = rechargeItemScriptGameConfiguration.TurnsExpression;
        SelectItemMessage = rechargeItemScriptGameConfiguration.SelectItemMessage;
        NonRechargeableItemMessage = rechargeItemScriptGameConfiguration.NonRechargeableItemMessage;
        NothingRechargeableMessage = rechargeItemScriptGameConfiguration.NothingRechargeableMessage;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        RechargeItemScriptGameConfiguration gameConfiguration = new()
        {
            Key = Key,
            TurnsExpression = TurnsExpression,
            SelectItemMessage = SelectItemMessage,
            NonRechargeableItemMessage = NonRechargeableItemMessage,
            NothingRechargeableMessage = NothingRechargeableMessage,
        };
        return JsonSerializer.Serialize(gameConfiguration, Game.GetJsonSerializerOptions());
    }

    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind()
    {
        Turns = Game.ParseNumericExpression(TurnsExpression);
    }

    protected virtual string TurnsExpression { get; }
    protected Expression Turns { get; private set; }
    protected virtual string SelectItemMessage { get; }
    protected virtual string NonRechargeableItemMessage { get; }
    protected virtual string NothingRechargeableMessage { get; }

    public override UsedResultEnum ExecuteUsedScript()
    {
        if (!Game.SelectItem(out Item? oPtr, SelectItemMessage, false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeRechargedItemFilter))))
        {
            Game.MsgPrint(NothingRechargeableMessage);
            return UsedResultEnum.False;
        }
        if (oPtr == null)
        {
            return UsedResultEnum.False;
        }
        // Make sure the item is rechargable
        if (oPtr.RechargeScript == null)
        {
            Game.MsgPrint(NonRechargeableItemMessage);
            return UsedResultEnum.False;
        }
        int turns = Game.ComputeIntegerExpression(Turns).Value;
        oPtr.RechargeScript.ExecuteScriptItemInt(oPtr, turns);
        return UsedResultEnum.True;
    }
}
