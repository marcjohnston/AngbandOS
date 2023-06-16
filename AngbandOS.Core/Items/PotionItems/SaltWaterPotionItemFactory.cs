// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SaltWaterPotionItemFactory : PotionItemFactory
{
    private SaltWaterPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Salt Water";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Salt Water";
    public override int? SubCategory => (int)PotionType.SaltWater;
    public override int Weight => 4;

    public override bool Quaff(SaveGame saveGame)
    {
        // Salt water makes you vomit, but gets rid of poison
        saveGame.MsgPrint("The saltiness makes you vomit!");
        saveGame.Player.SetFood(Constants.PyFoodStarve - 1);
        saveGame.Player.TimedPoison.ResetTimer();
        saveGame.Player.TimedParalysis.AddTimer(4);
        return true;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        return true;
    }
    public override Item CreateItem() => new SaltWaterPotionItem(SaveGame);
}
