// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class CloakOfElectricityRareItem : RareItem
{
    private CloakOfElectricityRareItem(Game game) : base(game) { } // This object is a singleton.
    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.BrightBrown;
    public override string Name => "Cloak of Electricity";
    public override int Cost => 4000;
    public override string FriendlyName => "of Electricity";
    public override bool IgnoreAcid => true;
    public override bool IgnoreElec => true;
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 4;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 16;
    public override bool ResElec => true;
    public override bool ShElec => true;
    public override int Slot => 31;
}
