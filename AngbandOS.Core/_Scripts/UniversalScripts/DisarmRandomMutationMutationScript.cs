namespace AngbandOS.Core.Scripts;
internal class DisarmRandomMutationMutationScript : UniversalScript, IGetKey
{
    private DisarmRandomMutationMutationScript(Game game) : base(game) { }
    public string GetKey => throw new NotImplementedException();

    public void Bind(RestoreGameState? restoreGameState) { }

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
        Game.MsgPrint("You drop your weapon!");
        Game.InvenDrop(InventorySlotEnum.MeleeWeapon, 1);
    }
}