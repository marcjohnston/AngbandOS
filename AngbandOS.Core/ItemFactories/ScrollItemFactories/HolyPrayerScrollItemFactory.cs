// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class HolyPrayerScrollItemFactory : ScrollItemFactory
{
    private HolyPrayerScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Holy Prayer";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 80;
    public override string FriendlyName => "Holy Prayer";
    public override int LevelNormallyFound => 25;
    public override int[] Locale => new int[] { 25, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (Game.BlessingTimer.AddTimer(Game.DieRoll(48) + 24))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}