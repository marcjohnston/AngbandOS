// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SpeedPotionItemFactory : PotionItemFactory
{
    private SpeedPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Speed";

    public override int[] Chance => new int[] { 1, 1, 1, 0 };
    public override int Cost => 75;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Speed";
    public override int LevelNormallyFound => 1;
    public override int[] Locale => new int[] { 1, 40, 60, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Speed temporarily hastes you.  But it is not additive.
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            if (SaveGame.TimedHaste.SetTimer(SaveGame.DieRoll(25) + 15))
            {
                return true;
            }
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(5);
        }
        return false;
    }

    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, 0, SaveGame.SingletonRepository.Projectiles.Get(nameof(OldSpeedProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
