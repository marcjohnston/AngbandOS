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
    public bool IsUsed => UsedResult == UsedResultEnum.True;
    public UsedResultEnum UsedResult { get; }
    public IdentifiedResultEnum IdentifiedResult { get; }
    public IdentifiedAndUsedResult(bool isIdentified, bool isUsed)
    {
        IdentifiedResult = isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
        UsedResult = isUsed ? UsedResultEnum.True : UsedResultEnum.False;
    }
    public IdentifiedAndUsedResult(IdentifiedResultEnum identifiedResult, bool isUsed)
    {
        IdentifiedResult = identifiedResult;
        UsedResult = isUsed ? UsedResultEnum.True : UsedResultEnum.False;
    }
    public IdentifiedAndUsedResult(bool isIdentified, UsedResultEnum usedResult)
    {
        IdentifiedResult = isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
        UsedResult = usedResult;
    }

    public IdentifiedAndUsedResult(IdentifiedResultEnum identifiedResult, UsedResultEnum usedResult)
    {
        IdentifiedResult = identifiedResult;
        UsedResult = usedResult;
    }
}
