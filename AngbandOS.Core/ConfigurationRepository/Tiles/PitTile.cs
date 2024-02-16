// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class PitTile : Tile
{
    private PitTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CaretSymbol));
    public override ColorEnum Color => ColorEnum.Grey;
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(DisarmAlterAction));
    public override string Description => "pit";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
    public override void StepOn(GridTile tile)
    {
        // A pit can be flown over with feather fall
        if (SaveGame.HasFeatherFall)
        {
            SaveGame.MsgPrint("You fly over a pit trap.");
        }
        else
        {
            SaveGame.MsgPrint("You fell into a pit!");
            // Pits do 2d6 fall damage
            int damage = SaveGame.DiceRoll(2, 6);
            string name = "a pit trap";
            SaveGame.TakeHit(damage, name);
        }
    }
}
