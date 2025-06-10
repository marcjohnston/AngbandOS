// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
public class UsedResult
{
    public bool IsUsed { get; set; }
    public UsedResult(bool isUsed)
    {
        IsUsed = isUsed;
    }
    public UsedResult(IdentifiedAndUsedResult identifiedAndUsedResult)
    {
        IsUsed = identifiedAndUsedResult.IsUsed;
    }
    public static UsedResult True => new UsedResult(true);
    public static UsedResult False => new UsedResult(false);
}
