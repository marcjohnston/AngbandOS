// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class WonderWandItemFactory : WandItemFactory
{
    private WonderWandItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(MinusSignSymbol));
    public override string Name => "Wonder";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(15) + 8;
    }

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Wonder";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 10;
    public override bool ExecuteActivation(Game game, int dir)
    {
        switch (Game.RandomLessThan(24))
        {
            case 0:
                // Acid ball
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 60, 2);
                return true;
            case 1:
                // Acid bolt
                game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, Game.DiceRoll(3, 8));
                return true;
            case 2:
                // CharmMonster
                return game.CharmMonster(dir, 45);
            case 3:
                // CloneMonster
                return game.CloneMonster(dir);
            case 4:
                // ColdBall
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 48, 2);
                return true;
            case 5:
                // ColdBolt
                game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, Game.DiceRoll(3, 8));
                return true;
            case 6:
                // ConfuseMonster
                return game.ConfuseMonster(dir, 10);
            case 7:
                // Disarming
                return game.DisarmTrap(dir);
            case 8:
                // DrainLife
                return game.DrainLife(dir, 75);
            case 9:
                // ElecBall
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 32, 2);
                return true;
            case 10:
                // FearMonster
                return game.FearMonster(dir, 10);
            case 11:
                // FireBall
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 72, 2);
                return true;
            case 12:
                // FireBolt
                game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(6, 8));
                return true;
            case 13:
                // HasteMonster
                return game.SpeedMonster(dir);
            case 14:
                // HealMonster
                return game.HealMonster(dir);
            case 15:
                // Light
                game.MsgPrint("A line of blue shimmering light appears.");
                game.LightLine(dir);
                return true;
            case 16:
                // MagicMissile
                game.FireBoltOrBeam(20, game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, Game.DiceRoll(2, 6));
                return true;
            case 17:
                // Polymorph
                return game.PolyMonster(dir);
            case 18:
                // SleepMonster
                return game.SleepMonster(dir);
            case 19:
                // SlowMonster
                return game.SlowMonster(dir);
            case 20:
                // StinkingCloud
                game.FireBall(game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), dir, 12, 2);
                return true;
            case 21:
                // StoneToMud
                return game.WallToMud(dir);
            case 22:
                // TeleportAway
                return game.TeleportMonster(dir);
            case 23:
                // TrapDoorDest
                return game.DestroyDoor(dir);
            default:
                throw new Exception("Internal error.");
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
