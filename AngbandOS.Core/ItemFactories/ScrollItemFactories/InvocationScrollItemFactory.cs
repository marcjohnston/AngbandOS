// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class InvocationScrollItemFactory : ScrollItemFactory
{
    private InvocationScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Invocation";

    public override int[] Chance => new int[] { 1, 2, 2, 0 };
    public override int Cost => 200;
    public override string FriendlyName => "Invocation";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 20, 40, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        var patron = Game.SingletonRepository.Patrons.ToWeightedRandom().ChooseOrDefault();
        Game.MsgPrint($"You invoke the secret name of {patron.LongName}.");
        patron.GetReward();
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}