// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class ResistancePotionItemFactory : PotionItemFactory
{
    private ResistancePotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Resistance";

    public override int[] Chance => new int[] { 1, 1, 1, 1 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Resistance";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 45, 80, 100 };
    public override int Pval => 100;
    public override int? SubCategory => (int)PotionType.Resistance;
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        // Resistance gives you all timed resistances
        saveGame.Player.TimedAcidResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        saveGame.Player.TimedLightningResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        saveGame.Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        saveGame.Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        saveGame.Player.TimedPoisonResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
        return true;
    }
    public override Item CreateItem() => new ResistancePotionItem(SaveGame);
}
