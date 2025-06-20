﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
public class IdentifiedResult
{
    public bool IsIdentified { get; set; }
    public IdentifiedResult(bool isIdentified)
    {
        IsIdentified = isIdentified;
    }
    public static IdentifiedResult True => new IdentifiedResult(true);
    public static IdentifiedResult False => new IdentifiedResult(false);
}
