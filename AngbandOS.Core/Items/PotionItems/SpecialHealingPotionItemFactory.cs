// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SpecialHealingPotionItemFactory : PotionItemFactory
{
    private SpecialHealingPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "*Healing*";

    public override int[] Chance => new int[] { 4, 2, 1, 0 };
    public override int Cost => 1500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "*Healing*";
    public override int Level => 40;
    public override int[] Locale => new int[] { 40, 60, 80, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
        // and bleeding
        if (SaveGame.RestoreHealth(1200))
        {
            identified = true;
        }
        if (SaveGame.TimedBlindness.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedConfusion.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedPoison.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedStun.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedBleeding.ResetTimer())
        {
            identified = true;
        }

        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 1, y, x, Program.Rng.DiceRoll(50, 50), SaveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new SpecialHealingPotionItem(SaveGame);
}
