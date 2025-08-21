namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class EatMagicMutationScript : UniversalScript, IGetKey
{
    private EatMagicMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
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