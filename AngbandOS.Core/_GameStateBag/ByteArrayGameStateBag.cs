// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;

namespace AngbandOS.Core;

internal class ByteArrayGameStateBag : GameStateBag
{
    public string Value { get; }
    public ByteArrayGameStateBag(byte[] value)
    {
        Value = Encoding.UTF8.GetString(value);
    }
    public override string ToString()
    {
        return $"{Value}";
    }
    public override void Verify(RestoreGameState restoreGameState, object? singleton)
    {
        if (singleton is not byte[] byteArraySingletonFieldValue)
        {
            throw new Exception($"During restore verification, the {singleton?.GetType().Name ?? "null"} singleton did not verify as a byte[] value.");
        }
        if (byteArraySingletonFieldValue.ToString() != Value)
        {
            throw new Exception($"During restore verification, the {singleton.GetType().Name} singleton did not verify.  Expected {Value}.");
        }
    }
}
