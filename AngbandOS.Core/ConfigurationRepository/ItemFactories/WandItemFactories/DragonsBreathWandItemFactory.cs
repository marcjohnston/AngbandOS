// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DragonsBreathWandItemFactory : WandItemFactory
{
    private DragonsBreathWandItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Dragon's Breath";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = SaveGame.Rng.DieRoll(3) + 1;
    }
    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 2400;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Dragon's Breath";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 60;
    public override int[] Locale => new int[] { 60, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(SaveGame saveGame, int dir)
    {
        switch (SaveGame.Rng.RandomLessThan(5))
        {
            case 0:
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(AcidProjectile)), dir, 100, -3);
                break;
            case 1:
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(ElecProjectile)), dir, 80, -3);
                break;
            case 2:
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(FireProjectile)), dir, 100, -3);
                break;
            case 3:
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(ColdProjectile)), dir, 80, -3);
                break;
            case 4:
                saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get(nameof(PoisProjectile)), dir, 60, -3);
                break;
            default:
                throw new Exception("Internal error.");
        }
        return true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}