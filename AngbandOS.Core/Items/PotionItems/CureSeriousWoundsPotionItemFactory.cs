// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CureSeriousWoundsPotionItemFactory : PotionItemFactory
{
    private CureSeriousWoundsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "Cure Serious Wounds";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 40;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cure Serious Wounds";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Pval => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Cure serious wounds heals you 4d8 health, cures blindness and confusion, and
        // reduces bleeding
        if (SaveGame.RestoreHealth(Program.Rng.DiceRoll(4, 8)))
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
        if (SaveGame.TimedBleeding.SetTimer((SaveGame.TimedBleeding.TurnsRemaining / 2) - 50))
        {
            identified = true;
        }
        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(4, 3), SaveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new CureSeriousWoundsPotionItem(SaveGame);
}
