// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class DisarmRandomMutation : Mutation
{
    private DisarmRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your feet grow to four times their former size.";
    public override string HaveMessage => "You occasionally stumble and drop things.";
    public override string LoseMessage => "Your feet shrink to their former size.";

    public override void ProcessWorld()
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