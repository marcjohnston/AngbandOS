namespace AngbandOS.Core.Scripts;
internal class DetectCursesMutationScript : ActiveMutationScript
{
    private DetectCursesMutationScript(Game game) : base(game) { }
    public override string Name => "detect curses";
    public override void ExecuteScript()
    {
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(slot);

                if (oPtr != null)
                {
                    if (oPtr.EffectiveAttributeSet.IsCursed)
                    {
                        oPtr.Inscription = "cursed";
                    }
                }
            }
        }
    }
}