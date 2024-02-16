// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Tiles;

[Serializable]
internal class SpikedPitTile : Tile
{
    private SpikedPitTile(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
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
            SaveGame.MsgPrint("You fly over a spiked pit.");
        }
        else
        {
            SaveGame.MsgPrint("You fall into a spiked pit!");
            string name = "a pit trap";
            // A pit does 2d6 fall damage
            int damage = SaveGame.DiceRoll(2, 6);
            // 50% chance of doing double damage plus bleeding
            if (SaveGame.RandomLessThan(100) < 50)
            {
                SaveGame.MsgPrint("You are impaled!");
                name = "a spiked pit";
                damage *= 2;
                SaveGame.TimedBleeding.AddTimer(SaveGame.DieRoll(damage));
            }
            SaveGame.TakeHit(damage, name);
        }
    }
}
