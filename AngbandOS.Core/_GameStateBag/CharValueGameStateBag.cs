// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class CharValueGameStateBag : GameStateBag
{
    public char Value { get; }
    public CharValueGameStateBag(char value)
    {
        Value = value;
    }
    public override void Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is not char charSingletonFieldValue)
        {
            throw new Exception($"During restore verification, the {singleton?.GetType().Name ?? "null"} singleton did not verify as a bool value.");
        }
        if (charSingletonFieldValue != Value)
        {
            throw new Exception($"During restore verification, the {singleton.GetType().Name} singleton did not verify.  Expected {Value}.");
        }
    }
}