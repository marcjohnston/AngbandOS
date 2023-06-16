namespace AngbandOS.Core.EventArgs;

internal class ZapRodEvent
{
    public Item Item { get; }

    /// <summary>
    /// Returns the direction specified by the player, if the command RequiresAiming == true; null, if the command doesn't require aiming.
    /// </summary>
    public int? Dir { get; }

    /// <summary>
    /// Returns whether or not the scroll was identified after being read.  Returns false, by default.  Set to true, to identify the scroll to the player.
    /// </summary>
    public bool Identified { get; set; } = false;

    /// <summary>
    /// Returns whether or not the rod is used up after being read.  Returns true, by default.  Set to false, to keep the scroll after being read.
    /// </summary>
    public bool UseCharge { get; set; } = true;

    public ZapRodEvent(Item item, int? dir)
    {
        Item = item;
        Dir = dir;
    }
}
