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
    private DisarmRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "Your feet grow to four times their former size.";
    public override string HaveMessage => "You occasionally stumble and drop things.";
    public override string LoseMessage => "Your feet shrink to their former size.";

    public override void OnProcessWorld()
    {
        if (base.SaveGame.DieRoll(10000) != 1)
        {
            return;
        }
        SaveGame.Disturb(false);
        SaveGame.MsgPrint("You trip over your own feet!");
        SaveGame.TakeHit(base.SaveGame.DieRoll(SaveGame.Weight / 6), "tripping");
        SaveGame.MsgPrint(null);
        Item? oPtr = SaveGame.GetInventoryItem(InventorySlot.MeleeWeapon);
        if (oPtr == null)
        {
            return;
        }
        SaveGame.MsgPrint("You drop your weapon!");
        SaveGame.InvenDrop(InventorySlot.MeleeWeapon, 1);
    }
}