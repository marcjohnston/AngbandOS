namespace AngbandOS.Core.Scripts;
    [Serializable]
internal class DetCurseMutationScript : UniversalScript, IGetKey
{
    private DetCurseMutationScript(Game game) : base(game) { }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }
    public override void ExecuteScript()
    {
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>())
        {
            foreach (int slot in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(slot);

                if (oPtr != null)
                {
                    if (oPtr.EffectivePropertySet.IsCursed)
                    {
                        oPtr.Inscription = "cursed";
                    }
                }
            }
        }
    }
}