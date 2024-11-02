// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.InventorySlots;

[Serializable]
internal class LightsourceInventorySlot : EquipmentInventorySlot
{
    private LightsourceInventorySlot(Game game) : base(game) { }
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

    public override void AddItem(Item item)
    {
        Game.SetInventoryItem(InventorySlot.Lightsource, item);
        Game.WeightCarried += item.Weight;
    }
    /// <summary>
    /// Consumes a turn of light during the ProcessWorldHook event.  Base inventory slot ProcessWorldHook processing occurs first, allowing light source items to process the event first.
    /// </summary>
    /// <param name="processWorldEventArgs"></param>
    public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
    {
        // Allow base processing to process the event.
        base.ProcessWorld(processWorldEventArgs);

        // Consume a turn of light.  The number of available turns of light is reduced by one for every item of light being wielded.
        bool hadLight = false; // True, if the player had light during the turn.
        int maxLight = 0; // The amount of light remaining on the lightsource with the most light.
        foreach (int index in InventorySlots)
        {
            Item? oPtr = Game.GetInventoryItem(index);
            if (oPtr != null && oPtr.BurnRate > 0 && oPtr.TurnsOfLightRemaining > 0)
            {
                hadLight = true;
                oPtr.TurnsOfLightRemaining -= oPtr.BurnRate;

                // If the player is blind, do not allow the light to go out completely.
                if (Game.BlindnessTimer.Value != 0)
                {
                    if (oPtr.TurnsOfLightRemaining == 0)
                    {
                        oPtr.TurnsOfLightRemaining++;
                    }
                }
                if (oPtr.TurnsOfLightRemaining > maxLight)
                {
                    maxLight = oPtr.TurnsOfLightRemaining;
                }
            }
        }
        if (hadLight && maxLight == 0)
        {
            Game.Disturb(true);
            Game.MsgPrint("Your light has gone out!");
        }
        else if (hadLight && maxLight < 100 && maxLight % 10 == 0)
        {
            Game.Disturb(true);
            Game.MsgPrint("Your light is growing faint.");
        }
    }
}