// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PitTile : TileGameConfiguration
{
    public override string SymbolName => nameof(CaretSymbol);
    public override ColorEnum Color => ColorEnum.Grey;
    public override string? AlterActionName => nameof(AlterActionsEnum.DisarmAlterAction);
    public override string Description => "pit";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
    public override string? StepOnScriptName => nameof(SystemScriptsEnum.PitTrapScript);
}
