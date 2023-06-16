// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class LightsourceInventorySlot : EquipmentInventorySlot
{
    private LightsourceInventorySlot(SaveGame saveGame) : base(saveGame) { }
    public override string Label(int index) => "g";
    public override string Label(Item oPtr) => "g";
    public override int[] InventorySlots => new int[] { InventorySlot.Lightsource };
    public override string MentionUse(int? index) => "Light source";
    public override string DescribeWieldLocation(int index) => "using to light the way";
    public override string DescribeItemLocation(Item oPtr) => "using to light the way";
    public override string WieldPhrase => "Your light source is";
    public override bool ProvidesLight => true;
    public override int SortOrder => 7;
    public override string TakeOffMessage(Item oPtr) => "You were holding";

    /// <summary>
    /// Consumes a turn of light during the ProcessWorldHook event.  Base inventory slot ProcessWorldHook processing occurs first, allowing light source items to process the event first.
    /// </summary>
    /// <param name="processWorldEventArgs"></param>
    public override void ProcessWorldHook(ProcessWorldEventArgs processWorldEventArgs)
    {
        // Allow base processing to process the event.
        base.ProcessWorldHook(processWorldEventArgs);

        // Consume a turn of light.  The number of available turns of light is reduced by one for every item of light being wielded.
        bool hadLight = false; // True, if the player had light during the turn.
        int maxLight = 0; // The amount of light remaining on the lightsource with the most light.
        foreach (int index in InventorySlots)
        {
            LightSourceItem? oPtr = (LightSourceItem?)SaveGame.GetInventoryItem(index);
            if (oPtr != null && oPtr.Category == ItemTypeEnum.Light)
            {
                if (oPtr.Factory.BurnRate > 0 && oPtr.TypeSpecificValue > 0)
                {
                    hadLight = true;
                    oPtr.TypeSpecificValue -= oPtr.Factory.BurnRate;

                    // If the player is blind, do not allow the light to go out completely.
                    if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
                    {
                        if (oPtr.TypeSpecificValue == 0)
                        {
                            oPtr.TypeSpecificValue++;
                        }
                    }
                    if (oPtr.TypeSpecificValue > maxLight)
                    {
                        maxLight = oPtr.TypeSpecificValue;
                    }
                }
            }
        }
        if (hadLight && maxLight == 0)
        {
            SaveGame.Disturb(true);
            SaveGame.MsgPrint("Your light has gone out!");
        }
        else if (hadLight && maxLight < 100 && maxLight % 10 == 0)
        {
            SaveGame.MsgPrint("Your light is growing faint.");
        }
    }
}