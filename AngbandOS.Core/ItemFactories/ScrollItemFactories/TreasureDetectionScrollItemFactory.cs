// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TreasureDetectionScrollItemFactory : ScrollItemFactory
{
    private TreasureDetectionScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Treasure Detection";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 15;
    public override string FriendlyName => "Treasure Detection";
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (Game.DetectTreasure())
        {
            eventArgs.Identified = true;
        }
        if (Game.DetectObjectsGold())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}