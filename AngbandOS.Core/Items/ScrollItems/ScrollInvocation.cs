// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollInvocation : ScrollItemClass
{
    private ScrollInvocation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<QuestionMarkSymbol>();
    public override string Name => "Invocation";

    public override int[] Chance => new int[] { 1, 2, 2, 0 };
    public override int Cost => 200;
    public override string FriendlyName => "Invocation";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 20, 40, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        var patron = eventArgs.SaveGame.SingletonRepository.Patrons.ToWeightedRandom().Choose();
        eventArgs.SaveGame.MsgPrint($"You invoke the secret name of {patron.LongName}.");
        patron.GetReward(eventArgs.SaveGame);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new InvocationScrollItem(SaveGame);
}
