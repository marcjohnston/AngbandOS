// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ScrollMonsterConfusion : ScrollItemClass
{
    private ScrollMonsterConfusion(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override string Name => "Monster Confusion";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 30;
    public override string FriendlyName => "Monster Confusion";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!eventArgs.SaveGame.Player.HasConfusingTouch)
        {
            eventArgs.SaveGame.MsgPrint("Your hands begin to glow.");
            eventArgs.SaveGame.Player.HasConfusingTouch = true;
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new MonsterConfusionScrollItem(SaveGame);
}
