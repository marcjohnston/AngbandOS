// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PoisonPotionItemFactory : PotionItemFactory
{
    private PoisonPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Poison";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Poison";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 4;

    public override bool Quaff(SaveGame saveGame)
    {
        // Poison simply poisons you
        if (!(saveGame.Player.HasPoisonResistance || saveGame.Player.TimedPoisonResistance.TurnsRemaining != 0))
        {
            // Hagarg Ryonis can protect you against poison
            if (Program.Rng.DieRoll(10) <= saveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                saveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (saveGame.Player.TimedPoison.AddTimer(Program.Rng.RandomLessThan(15) + 10))
            {
                return true;
            }
        }
        return false;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 2, y, x, 3, saveGame.SingletonRepository.Projectiles.Get<PoisProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new PoisonPotionItem(SaveGame);
}
