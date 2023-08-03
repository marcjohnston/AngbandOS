// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
/// <summary>
/// Represents armour items.  Boots, cloaks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
/// </summary>
internal abstract class ArmourItemFactory : ItemFactory
{
    public ArmourItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override bool HasQuality => true;

    public override int RandartActivationChance => base.RandartActivationChance * 2;

    /// <summary>
    /// Returns true, for all armour where the armour class (ToA) is greater than or equal to zero.
    /// </summary>
    public override bool KindIsGood => ToA >= 0;
}
