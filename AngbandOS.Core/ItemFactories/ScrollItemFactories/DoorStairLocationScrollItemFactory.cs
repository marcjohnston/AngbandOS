// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DoorStairLocationScrollItemFactory : ScrollItemFactory
{
    private DoorStairLocationScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Door/Stair Location";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 35;
    public override string FriendlyName => "Door/Stair Location";
    public override int LevelNormallyFound => 5;
    public override int[] Locale => new int[] { 5, 10, 15, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (Game.DetectDoors())
        {
            eventArgs.Identified = true;
        }
        if (Game.DetectStairs())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}