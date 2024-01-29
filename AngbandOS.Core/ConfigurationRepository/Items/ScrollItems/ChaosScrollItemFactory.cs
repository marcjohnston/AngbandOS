// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ChaosScrollItemFactory : ScrollItemFactory
{
    private ChaosScrollItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(QuestionMarkSymbol));
    public override string Name => "Chaos";

    public override int[] Chance => new int[] { 8, 0, 0, 0 };
    public override int Cost => 10000;
    public override string FriendlyName => "Chaos";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 100;
    public override int[] Locale => new int[] { 100, 0, 0, 0 };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)), 0, 222, 4);
        if (!SaveGame.HasChaosResistance)
        {
            SaveGame.TakeHit(111 + SaveGame.Rng.DieRoll(111), "a Scroll of Chaos");
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
