// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class ResistancePotionItemFactory : PotionItemFactory
{
    private ResistancePotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(ExclamationPointSymbol));
    public override string Name => "Resistance";

    public override int[] Chance => new int[] { 1, 1, 1, 1 };
    public override int Cost => 250;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Resistance";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int LevelNormallyFound => 20;
    public override int[] Locale => new int[] { 20, 45, 80, 100 };
    public override int InitialTypeSpecificValue => 100;
    public override int Weight => 4;
    public override bool Quaff()
    {
        // Resistance gives you all timed resistances
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.ColdResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.PoisonResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        return true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
