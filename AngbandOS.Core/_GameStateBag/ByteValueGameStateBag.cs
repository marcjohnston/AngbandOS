// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text.Json.Serialization;

namespace AngbandOS.Core;
    internal class ByteValueGameStateBag : GameStateBag
{
    public byte Value { get; }
    public  ByteValueGameStateBag(byte value)
    {
        Value = value;
    }
}