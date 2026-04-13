// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class QueueOfStringGameStateBag : GameStateBag
{
    public string?[] Values { get; }
    public QueueOfStringGameStateBag(string?[] values)
    {
        Values = values;
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is not Queue<string> queueOfStringSingletonFieldValue)
        {
            throw new Exception($"During restore verification, the {singleton?.GetType().Name ?? "null"} singleton did not verify as a Queue<string> value.");
        }
        return Values.SequenceEqual(queueOfStringSingletonFieldValue);
    }
}