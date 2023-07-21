// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Items;

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CureCriticalWoundsPotionItemFactory : PotionItemFactory
{
    private CureCriticalWoundsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Cure Critical Wounds";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cure Critical Wounds";
    public override int Level => 5;
    public override int[] Locale => new int[] { 5, 0, 0, 0 };
    public override int Pval => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Cure critical wounds heals you 6d8 health, and cures blindness, confusion, stun,
        // poison, and bleeding
        if (SaveGame.Player.RestoreHealth(Program.Rng.DiceRoll(6, 8)))
        {
            identified = true;
        }
        if (SaveGame.Player.TimedBlindness.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.Player.TimedConfusion.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.Player.TimedPoison.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.Player.TimedStun.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.Player.TimedBleeding.ResetTimer())
        {
            identified = true;
        }

        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(6, 3), SaveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new CureCriticalWoundsPotionItem(SaveGame);
}
