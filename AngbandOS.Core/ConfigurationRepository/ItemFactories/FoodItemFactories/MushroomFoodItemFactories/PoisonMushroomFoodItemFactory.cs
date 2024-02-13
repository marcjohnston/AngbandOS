// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PoisonMushroomFoodItemFactory : MushroomFoodItemFactory
{
    private PoisonMushroomFoodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CommaSymbol));
    public override string Name => "Poison";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Dd => 4;
    public override int Ds => 4;
    public override string FriendlyName => "Poison";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 5, 0, 0 };
    public override int InitialTypeSpecificValue => 500;
    public override int Weight => 1;

    public override bool Eat()
    {
        SaveGame.PlaySound(SoundEffectEnum.Eat);
        if (!(SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.TurnsRemaining != 0))
        {
            // Hagarg Ryonis may protect us from poison
            if (SaveGame.DieRoll(10) <= SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (SaveGame.TimedPoison.AddTimer(SaveGame.RandomLessThan(10) + 10))
            {
                return true;
            }
        }
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
