// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BoozePotionItemFactory : PotionItemFactory
{
    private BoozePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Booze";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Booze";
    public override int Pval => 50;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;

        // Confusion makes you confused and possibly other effects
        if (!(SaveGame.HasConfusionResistance || SaveGame.HasChaosResistance))
        {
            if (SaveGame.TimedConfusion.AddTimer(SaveGame.Rng.RandomLessThan(20) + 15))
            {
                identified = true;
            }
            // 50% chance of having hallucinations
            if (SaveGame.Rng.DieRoll(2) == 1)
            {
                if (SaveGame.TimedHallucinations.AddTimer(SaveGame.Rng.RandomLessThan(150) + 150))
                {
                    identified = true;
                }
            }
            // 1 in 13 chance of blacking out and waking up somewhere else
            if (SaveGame.Rng.DieRoll(13) == 1)
            {
                identified = true;
                // 1 in 3 chance of losing your memories after blacking out
                if (SaveGame.Rng.DieRoll(3) == 1)
                {
                    SaveGame.LoseAllInfo();
                }
                else
                {
                    SaveGame.RunScript(nameof(WizardDarkScript));
                }
                SaveGame.TeleportPlayer(100);
                SaveGame.RunScript(nameof(WizardDarkScript));
                SaveGame.MsgPrint("You wake up somewhere with a sore head...");
                SaveGame.MsgPrint("You can't remember a thing, or how you got here!");
            }
        }
        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, 0, SaveGame.SingletonRepository.Projectiles.Get(nameof(OldConfProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
    public override Item CreateItem() => new BoozePotionItem(SaveGame);
}
