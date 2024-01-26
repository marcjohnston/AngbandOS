// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class StrengthDartTile : Tile
{
    private StrengthDartTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CaretSymbol));
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "StrDart";
    public override AlterAction? AlterAction => SaveGame.SingletonRepository.AlterActions.Get(nameof(DisarmAlterAction));
    public override string AppearAs => "StrDart";
    public override string Description => "dart trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
