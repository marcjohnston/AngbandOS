// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IocainePotionItemFactory : PotionItemFactory
{
    private IocainePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Iocaine";

    public override int DamageDice => 20;
    public override int DamageSides => 20;
    public override string FriendlyName => "Iocaine";
    public override int LevelNormallyFound => 55;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (55, 4)
    };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Iocaine simply does 5000 damage
        Game.MsgPrint("A feeling of Death flows through your body.");
        Game.TakeHit(5000, "a potion of Death");
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        Game.Project(who, 1, y, x, 0, Game.SingletonRepository.Get<Projectile>(nameof(DeathRayProjectile)), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
        return true;
    }
}
