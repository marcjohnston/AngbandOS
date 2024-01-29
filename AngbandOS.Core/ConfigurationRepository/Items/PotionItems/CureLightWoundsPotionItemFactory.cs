// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CureLightWoundsPotionItemFactory : PotionItemFactory
{
    private CureLightWoundsPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Cure Light Wounds";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 15;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Cure Light Wounds";
    public override int[] Locale => new int[] { 0, 1, 3, 0 };
    public override int InitialTypeSpecificValue => 50;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Cure light wounds heals you 2d8 health and reduces bleeding
        if (SaveGame.RestoreHealth(SaveGame.Rng.DiceRoll(2, 8)))
        {
            identified = true;
        }
        if (SaveGame.TimedBleeding.AddTimer(-10))
        {
            identified = true;
        }
        return identified;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, SaveGame.Rng.DiceRoll(2, 3), SaveGame.SingletonRepository.Projectiles.Get(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
