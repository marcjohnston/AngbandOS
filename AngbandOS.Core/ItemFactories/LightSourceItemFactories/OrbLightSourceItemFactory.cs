// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OrbLightSourceItemFactory : LightSourceItemFactory
{
    private OrbLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(TildeSymbol));
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "Orb";

    /// <summary>
    /// Returns an intensity of light provided by the orb.  A value of 2 is returned, plus an additional 3
    /// if the orb is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch(Item item)
    {
        return base.CalculateTorch(item) + 2;
    }

    public override bool IdentityCanBeSensed => true;
    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;

    public override int Ds => 1;
    public override string FriendlyName => "& Orb~";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 50;

    public override bool HasQuality => true;
    public override Item CreateItem() => new Item(Game, this);
}