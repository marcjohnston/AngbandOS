// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class FireScrollItemFactory : ScrollItemFactory
{
    private FireScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Fire";

    public override int Cost => 1000;
    public override string FriendlyName => "Fire";
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 4)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile)), 0, 150, 4);
        if (!(Game.FireResistanceTimer.Value != 0 || Game.HasFireResistance || Game.HasFireImmunity))
        {
            Game.TakeHit(50 + Game.DieRoll(50), "a Scroll of Fire");
        }
        eventArgs.Identified = true;
    }
}
