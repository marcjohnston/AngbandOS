// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CreateRandomArtifactScript : Script, IScript
{
    private CreateRandomArtifactScript(Game game) : base(game) { }

    /// <summary>
    /// Creates an artifact from a chosen item.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool okay;
        if (!Game.SelectItem(out Item? oPtr, "Enchant which item? ", true, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(WeaponsItemFilter))))
        {
            Game.MsgPrint("You have nothing to enchant.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        string oName = oPtr.GetDescription(false);
        string your = oPtr.IsInInventory ? "Your" : "The";
        string s = oPtr.StackCount > 1 ? "" : "s";
        Game.MsgPrint($"{your} {oName} radiate{s} a blinding light!");
        if (oPtr.IsArtifact)
        {
            string are = oPtr.StackCount > 1 ? "are" : "is";
            s = oPtr.StackCount > 1 ? "artifacts" : "an artifact";
            Game.MsgPrint($"The {oName} {are} already {s}!");
            okay = false;
        }
        else if (oPtr.RareItem != null)
        {
            string are = oPtr.StackCount > 1 ? "are" : "is";
            s = oPtr.StackCount > 1 ? "rare items" : "a rare item";
            Game.MsgPrint($"The {oName} {are} already {s}!");
            okay = false;
        }
        else
        {
            if (oPtr.StackCount > 1)
            {
                Game.MsgPrint("Not enough energy to enchant more than one object!");
                s = oPtr.StackCount > 2 ? "were" : "was";
                Game.MsgPrint($"{oPtr.StackCount - 1} of your {oName} {s} destroyed!");
                oPtr.StackCount = 1;
            }
            okay = oPtr.CreateRandomArtifact(true);
        }
        if (!okay)
        {
            Game.MsgPrint("The enchantment failed.");
        }
    }
}
