// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class HealingPotionItemFactory : PotionItemFactory
{
    private HealingPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Healing";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 300;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Healing";
    public override int Level => 15;
    public override int[] Locale => new int[] { 15, 30, 60, 0 };
    public override int Pval => 200;
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        bool identified = false;

        // Healing heals you 300 health, and cures blindness, confusion, stun, poison, and bleeding
        if (saveGame.Player.RestoreHealth(300))
        {
            identified = true;
        }
        if (saveGame.Player.TimedBlindness.ResetTimer())
        {
            identified = true;
        }
        if (saveGame.Player.TimedConfusion.ResetTimer())
        {
            identified = true;
        }
        if (saveGame.Player.TimedPoison.ResetTimer())
        {
            identified = true;
        }
        if (saveGame.Player.TimedStun.ResetTimer())
        {
            identified = true;
        }
        if (saveGame.Player.TimedBleeding.ResetTimer())
        {
            identified = true;
        }

        return identified;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(10, 10), saveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new HealingPotionItem(SaveGame);
}
