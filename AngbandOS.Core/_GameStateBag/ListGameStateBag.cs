// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;

namespace AngbandOS.Core;

internal class ListGameStateBag : GameStateBag
{
    public GameStateBag[] Values { get; }
    public ListGameStateBag(params GameStateBag[] values)
    {
        Values = values;
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is IEnumerable enumerableSingleton)
        {
            IEnumerator enumerator = enumerableSingleton.GetEnumerator();
            foreach (GameStateBag gameStateBag in Values)
            {
                if (!enumerator.MoveNext())
                {
                    throw new Exception("List did not verify ... not enough items.");
                }
                if (!restoreGameState.New(gameStateBag).Verify(enumerator.Current))
                {
                    throw new Exception("List did not verify.");
                }
            }
            return true;
        }
        throw new Exception($"During restore verification, the {singleton?.GetType().Name ?? "null"} singleton did not verify as an integer value.");
    }
}
