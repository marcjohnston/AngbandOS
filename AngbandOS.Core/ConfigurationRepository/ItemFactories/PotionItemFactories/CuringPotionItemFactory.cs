// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class CuringPotionItemFactory : PotionItemFactory
{
    private CuringPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Curing";

    public override int[] Chance => new int[] { 1, 1, 0, 0 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Curing";
    public override int Level => 18;
    public override int[] Locale => new int[] { 18, 40, 0, 0 };
    public override int InitialTypeSpecificValue => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        bool identified = false;
        // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
        // bleeding, and hallucinations
        if (SaveGame.RestoreHealth(50))
        {
            identified = true;
        }
        if (SaveGame.TimedBlindness.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedPoison.ResetTimer())
        {
            identified = true;
        }
        if (SaveGame.TimedConfusion.ResetTimer())
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
        if (SaveGame.TimedHallucinations.ResetTimer())
        {
            identified = true;
        }
        return identified;
    }
    public override bool Smash(int who, int y, int x)
    {
        SaveGame.Project(who, 2, y, x, SaveGame.Rng.DiceRoll(6, 3), SaveGame.SingletonRepository.Projectiles.Get(nameof(OldHealProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return false;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}