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
    public bool IsIdentified => IdentifiedResult == IdentifiedResultEnum.True;
    public bool IsUsed { get; set; }
    public UsedResult UsedResult => new UsedResult(IsUsed);
    public IdentifiedResultEnum IdentifiedResult { get; }
    public IdentifiedAndUsedResult(bool isIdentified, bool isUsed)
    {
        IdentifiedResult = isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
        IsUsed = isUsed;
    }
    public IdentifiedAndUsedResult(IdentifiedResultEnum identifiedResult, bool isUsed)
    {
        IdentifiedResult = identifiedResult;
        IsUsed = isUsed;
    }
    public IdentifiedAndUsedResult(bool isIdentified, UsedResult usedResult)
    {
        IdentifiedResult = isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
        IsUsed = usedResult.IsUsed;
    }

    public IdentifiedAndUsedResult(IdentifiedResultEnum identifiedResult, UsedResult usedResult)
    {
        IdentifiedResult = identifiedResult;
        IsUsed = usedResult.IsUsed;
    }
}
