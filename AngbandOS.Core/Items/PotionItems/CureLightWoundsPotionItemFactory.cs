// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CureLightWoundsPotionItemFactory : PotionItemFactory
{
    private CureLightWoundsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '!';
    public override string Name => "Cure Light Wounds";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 15;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cure Light Wounds";
    public override int[] Locale => new int[] { 0, 1, 3, 0 };
    public override int Pval => 50;
    public override int? SubCategory => (int)PotionType.CureLight;
    public override int Weight => 4;
    public override bool Quaff(SaveGame saveGame)
    {
        bool identified = false;
        // Cure light wounds heals you 2d8 health and reduces bleeding
        if (saveGame.Player.RestoreHealth(Program.Rng.DiceRoll(2, 8)))
        {
            identified = true;
        }
        if (saveGame.Player.TimedBleeding.AddTimer(-10))
        {
            identified = true;
        }
        return identified;
    }

    public override bool Smash(SaveGame saveGame, int who, int y, int x)
    {
        saveGame.Project(who, 2, y, x, Program.Rng.DiceRoll(2, 3), saveGame.SingletonRepository.Projectiles.Get<OldHealProjectile>(), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new CureLightWoundsPotionItem(SaveGame);
}
