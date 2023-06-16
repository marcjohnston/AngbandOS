// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Talents;

[Serializable]
internal class TalentPsychometry : Talent
{
    public override string Name => "Psychometry";
    public override void Initialise(int characterClass)
    {
        Level = 15;
        ManaCost = 12;
        BaseFailure = 60;
    }

    public override void Use(SaveGame saveGame)
    {
        if (saveGame.Player.Level < 40)
        {
            Psychometry(saveGame);
        }
        else
        {
            saveGame.IdentifyItem();
        }
    }

    protected override string Comment(Player player)
    {
        return string.Empty;
    }

    private void Psychometry(SaveGame saveGame)
    {
        if (!saveGame.SelectItem(out Item? oPtr, "Meditate on which item? ", true, true, true, null))
        {
            saveGame.MsgPrint("You have nothing appropriate.");
            return;
        }
        if (oPtr == null)
        {
            return;
        }
        if (oPtr.IsKnown() || oPtr.IdentSense)
        {
            saveGame.MsgPrint("You cannot find out anything more about that.");
            return;
        }
        string feel = oPtr.GetDetailedFeeling();
        string oName = oPtr.Description(false, 0);
        if (string.IsNullOrEmpty(feel))
        {
            saveGame.MsgPrint($"You do not perceive anything unusual about the {oName}.");
            return;
        }
        string s = oPtr.Count == 1 ? "is" : "are";
        saveGame.MsgPrint($"You feel that the {oName} {s} {feel}...");
        oPtr.IdentSense = true;
        if (string.IsNullOrEmpty(oPtr.Inscription))
        {
            oPtr.Inscription = feel;
        }
        saveGame.NoticeCombineAndReorderFlaggedAction.Set();
    }
}