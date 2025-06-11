// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interface.Configuration;

[Serializable]
public class SymbolGameConfiguration
{
    public virtual char Character { get; set; }
    public virtual char? QueryCharacter { get; set; } = null;
    public virtual string Name { get; set; }

    public virtual string? Key { get; set; } = null;
}
