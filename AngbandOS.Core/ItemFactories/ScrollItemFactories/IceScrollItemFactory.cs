// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class IceScrollItemFactory : ScrollItemFactory
{
    private IceScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Ice";

    public override int[] Chance => new int[] { 6, 0, 0, 0 };
    public override int Cost => 5000;
    public override string FriendlyName => "Ice";
    public override bool IgnoreCold => true;
    public override int LevelNormallyFound => 75;
    public override int[] Locale => new int[] { 75, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(IceProjectile)), 0, 175, 4);
        if (!(Game.ColdResistanceTimer.Value != 0 || Game.HasColdResistance || Game.HasColdImmunity))
        {
            Game.TakeHit(100 + Game.DieRoll(100), "a Scroll of Ice");
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}