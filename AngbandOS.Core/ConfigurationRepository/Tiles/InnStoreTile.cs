﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class InnStoreTile : Tile
{
    private InnStoreTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override bool BlocksLos => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(AmpersandSymbol));
    public override ColorEnum Color => ColorEnum.Purple;
    public override string Name => "Inn";
    public override string AppearAs => "Inn";
    public override string Description => "Inn";
}
