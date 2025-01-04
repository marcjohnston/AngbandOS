// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
public class IdentifiedAndUsedResult
{
    public bool IsIdentified { get; set; }
    public bool IsUsed { get; set; }
    public UsedResult UsedResult => new UsedResult(IsUsed);
    public IdentifiedResult IdentifiedResult => new IdentifiedResult(IsIdentified);
    public IdentifiedAndUsedResult(bool isIdentified, bool isUsed)
    {
        IsIdentified = isIdentified;
        IsUsed = isUsed;
    }
    public IdentifiedAndUsedResult(IdentifiedResult identifiedResult, bool isUsed)
    {
        IsIdentified = identifiedResult.IsIdentified;
        IsUsed = isUsed;
    }
    public IdentifiedAndUsedResult(bool isIdentified, UsedResult usedResult)
    {
        IsIdentified = isIdentified;
        IsUsed = usedResult.IsUsed;
    }

    public IdentifiedAndUsedResult(IdentifiedResult identifiedResult, UsedResult usedResult)
    {
        IsIdentified = identifiedResult.IsIdentified;
        IsUsed = usedResult.IsUsed;
    }
}
