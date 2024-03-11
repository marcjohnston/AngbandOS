// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PoisonPotionItemFactory : PotionItemFactory
{
    private PoisonPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Poison";
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Poison simply poisons you
        if (!(SaveGame.HasPoisonResistance || SaveGame.TimedPoisonResistance.Value != 0))
        {
            // Hagarg Ryonis can protect you against poison
            if (SaveGame.DieRoll(10) <= SaveGame.SingletonRepository.Gods.Get(nameof(HagargRyonisGod)).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (SaveGame.PoisonTimer.AddTimer(SaveGame.RandomLessThan(15) + 10))
            {
                return true;
            }
        }
        return false;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, 3, SaveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
