namespace AngbandOS.Core.Scripts;
internal class DisarmRandomMutationScript : UniversalScript
{
    private DisarmRandomMutationScript(Game game) : base(game) { }

    public override void ExecuteScript()
    {
        if (base.Game.DieRoll(10000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("You trip over your own feet!");
        Game.TakeHit(base.Game.DieRoll(Game.Weight / 6), "tripping");
        Game.MsgPrint(string.Empty);
        Item? oPtr = Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon);
        if (oPtr == null)
        {
            return;
        }
        Item? item = Game.GetInventoryItem(InventorySlotEnum.MeleeWeapon);
        if (item is not null)
        {
            Game.MsgPrint("You drop your weapon!");
            Game.InvenDrop(item, 1);
        }
    }
}