// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class BowOfExtraShotsRareItem : RareItem
{
    private BowOfExtraShotsRareItem(Game game) : base(game) { } // This object is a singleton.
    public override int Cost => 10000;
    public override string FriendlyName => "of Extra Shots";
    public override int Level => 0;
    public override int MaxPval => 0;
    public override int MaxToA => 0;
    public override int MaxToD => 5;
    public override int MaxToH => 10;
    public override int Rarity => 0;
    public override int Rating => 20;
    public override int Slot => 25;
    public override bool XtraShots => true;
}
