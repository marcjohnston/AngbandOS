// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class IntValueGameStateBag : GameStateBag
{
    public int Value { get; }
    public IntValueGameStateBag(int value)
    {
        Value = value;
    }
    public override bool Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is Enum)
        {
            return (int)singleton == Value;
        }
        if (singleton is int intSingletonFieldValue)
        {
            return intSingletonFieldValue == Value;
        }
        throw new Exception($"During restore verification, the {singleton?.GetType().Name ?? "null"} singleton did not verify as an integer value.");
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}
