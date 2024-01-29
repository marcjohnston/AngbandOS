// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class BoltAmmunitionItemFactory : AmmunitionItemFactory
{
    public BoltAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(BoltsItemClass));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Bolt;
    public override int PackSort => 33;
    public override ColorEnum Color => ColorEnum.BrightBrown;

    /// <summary>
    /// Returns true for all bolts.
    /// </summary>
    public override bool KindIsGood => true;


    public override bool HatesAcid => true;
}
