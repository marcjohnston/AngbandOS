// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class InfravisionPotionItemFactory : PotionItemFactory
{
    private InfravisionPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(ExclamationPointSymbol));
    public override string Name => "Infra-vision";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 20;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Infra-vision";
    public override int Level => 3;
    public override int[] Locale => new int[] { 3, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Infravision gives you timed infravision
        return SaveGame.TimedInfravision.AddTimer(100 + SaveGame.DieRoll(100));
    }
    public override Item CreateItem() => new Item(SaveGame, this);
}
