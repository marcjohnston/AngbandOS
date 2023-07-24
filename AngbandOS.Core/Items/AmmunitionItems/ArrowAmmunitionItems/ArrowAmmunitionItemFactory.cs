// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class ArrowAmmunitionItemFactory : AmmunitionItemFactory
{
    public ArrowAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<ArrowsItemClass>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Arrow;
    public override int PackSort => 34;
    public override bool HatesFire => true;
    public override bool HatesAcid => true;
    /// <summary>
    /// Returns true, for all arrows.
    /// </summary>
    public override bool KindIsGood => true;


    public override ColourEnum Colour => ColourEnum.BrightBrown;
}
