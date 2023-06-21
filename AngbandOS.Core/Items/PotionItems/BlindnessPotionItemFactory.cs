// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BlindnessPotionItemFactory : PotionItemFactory
{
    private BlindnessPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Blindness";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Blindness";
    public override int Weight => 4;

    public override bool Quaff(SaveGame saveGame)
    {
        // Blindness makes you blind
        if (!saveGame.Player.HasBlindnessResistance)
            return saveGame.Player.TimedBlindness.AddTimer(Program.Rng.RandomLessThan(100) + 100);
        return false;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 2, y, x, 0, saveGame.SingletonRepository.Projectiles.Get<DarkProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new BlindnessPotionItem(SaveGame);
}
