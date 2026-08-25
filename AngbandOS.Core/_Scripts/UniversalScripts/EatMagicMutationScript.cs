namespace AngbandOS.Core.Scripts;
internal class EatMagicMutationScript : ActiveMutationScript
{
    private EatMagicMutationScript(Game game) : base(game) { }
    public override string Name => "eat magic";
    public override void ExecuteScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Drain which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeRechargedItemFilter))))
        {
            Game.MsgPrint("You have nothing appropriate to eat.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }

        // Make sure the item is actually edible
        if (oPtr.EatMagicScript == null)
        {
            Game.MsgPrint("That is not a rod!");
            return;
        }

        int lev = oPtr.LevelNormallyFound;
        oPtr.EatMagicScript.ExecuteScriptItem(oPtr);
        if (Game.Mana.IntValue > Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }
}