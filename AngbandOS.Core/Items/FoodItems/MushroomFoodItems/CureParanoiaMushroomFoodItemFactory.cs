// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CureParanoiaMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private CureParanoiaMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override string Name => "Cure Paranoia";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 25;
    public override string FriendlyName => "Cure Paranoia";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Pval => 500;
    public override int? SubCategory => 14;
    public override int Weight => 1;
    public override bool Eat()
    {
        if (SaveGame.Player.TimedFear.ResetTimer())
        {
            return true;
        }
        return false;
    }
    public override Item CreateItem() => new CureParanoiaMushroomFoodItem(SaveGame);
}
