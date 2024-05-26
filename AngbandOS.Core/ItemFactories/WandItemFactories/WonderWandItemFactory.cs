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

    protected override string SymbolName => nameof(MinusSignSymbol);
    public override string Name => "Wonder";
    protected override string? DescriptionSyntax => "$Flavor$ Wand~ of $Name$";
    protected override string? FlavorUnknownDescriptionSyntax => "$Flavor$ Wand~";
    protected override string? FlavorSuppressedDescriptionSyntax => "Wand~ of $Name$";
    public override int RodChargeCount => Game.DieRoll(15) + 8;

    public override int Cost => 250;
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 3;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (3, 1)
    };
    public override int Weight => 10;
    public override bool ActivateWand(int dir)
    {
        switch (Game.RandomLessThan(24))
        {
            case 0:
                // Acid ball
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, 60, 2);
                return true;
            case 1:
                // Acid bolt
                Game.FireBoltOrBeam(20, Game.SingletonRepository.Get<Projectile>(nameof(AcidProjectile)), dir, Game.DiceRoll(3, 8));
                return true;
            case 2:
                // CharmMonster
                return Game.CharmMonster(dir, 45);
            case 3:
                // CloneMonster
                return Game.CloneMonster(dir);
            case 4:
                // ColdBall
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 48, 2);
                return true;
            case 5:
                // ColdBolt
                Game.FireBoltOrBeam(20, Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, Game.DiceRoll(3, 8));
                return true;
            case 6:
                // ConfuseMonster
                return Game.ConfuseMonster(dir, 10);
            case 7:
                // Disarming
                return Game.DisarmTrap(dir);
            case 8:
                // DrainLife
                return Game.DrainLife(dir, 75);
            case 9:
                // ElecBall
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ElecProjectile)), dir, 32, 2);
                return true;
            case 10:
                // FearMonster
                return Game.FearMonster(dir, 10);
            case 11:
                // FireBall
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, 72, 2);
                return true;
            case 12:
                // FireBolt
                Game.FireBoltOrBeam(20, Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), dir, Game.DiceRoll(6, 8));
                return true;
            case 13:
                // HasteMonster
                return Game.SpeedMonster(dir);
            case 14:
                // HealMonster
                return Game.HealMonster(dir);
            case 15:
                // Light
                Game.MsgPrint("A line of blue shimmering light appears.");
                Game.LightLine(dir);
                return true;
            case 16:
                // MagicMissile
                Game.FireBoltOrBeam(20, Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile)), dir, Game.DiceRoll(2, 6));
                return true;
            case 17:
                // Polymorph
                return Game.PolyMonster(dir);
            case 18:
                // SleepMonster
                return Game.SleepMonster(dir);
            case 19:
                // SlowMonster
                return Game.SlowMonster(dir);
            case 20:
                // StinkingCloud
                Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(PoisProjectile)), dir, 12, 2);
                return true;
            case 21:
                // StoneToMud
                return Game.WallToMud(dir);
            case 22:
                // TeleportAway
                return Game.TeleportMonster(dir);
            case 23:
                // TrapDoorDest
                return Game.DestroyDoor(dir);
            default:
                throw new Exception("Internal error.");
        }
    }
}
