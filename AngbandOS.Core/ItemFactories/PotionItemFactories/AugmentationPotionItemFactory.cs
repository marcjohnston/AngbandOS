// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class AugmentationPotionItemFactory : PotionItemFactory
{
    private AugmentationPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Augmentation";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Augmentation";
    public override int LevelNormallyFound => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        return Game.RunNoticeableScript(nameof(AugmentScript));
    }
    public override Item CreateItem() => new Item(Game, this);
}