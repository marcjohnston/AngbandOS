// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class HatOfMightRareItem : RareItem
{
    private HatOfMightRareItem(Game game) : base(game) { } // This object is a singleton.
    public override bool Con => true;
    public override int Cost => 2000;
    public override bool Dex => true;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Might";
    public override int Level => 0;
    public override int MaxPval => 3;
    public override int MaxToA => 0;
    public override int MaxToD => 0;
    public override int MaxToH => 0;
    public override int Rarity => 0;
    public override int Rating => 19;
    public override int Slot => 33;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustStr => true;
}
