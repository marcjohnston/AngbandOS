// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RareItems;

[Serializable]
internal class WeaponOfSlayAnimalRareItem : RareItem
{
    private WeaponOfSlayAnimalRareItem(Game game) : base(game) { } // This object is a singleton.
    public override int Cost => 3500;
    public override string FriendlyName => "of Slay Animal";
    public override int Rating => 18;
    public override bool SlayAnimal => true;
    public override int Slot => 24;
}
