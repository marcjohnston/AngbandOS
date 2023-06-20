// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HardBiscuitFoodItemFactory : FoodItemFactory
{
    private HardBiscuitFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => ',';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Hard Biscuit";

    public override int Cost => 1;
    public override string FriendlyName => "& Hard Biscuit~";
    public override int Pval => 500;
    public override int? SubCategory => 32;
    public override int Weight => 2;
    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffect.Eat);
        SaveGame.MsgPrint("That tastes good.");
        return true;
    }

    public override void ApplyFlavourVisuals()
    {
        base.ApplyFlavourVisuals();
    }

    /// <summary>
    /// Returns true because biscuits vanish when a skeleton tries to eat it.
    /// </summary>
    public override bool VanishesWhenEatenBySkeletons => true;

    public override Item CreateItem() => new HardBiscuitFoodItem(SaveGame);
}
