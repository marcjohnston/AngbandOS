// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class LifeBookItemFactory : BookItemFactory
{
    public LifeBookItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<LifeSpellBooksItemClass>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.LifeBook;
    public override bool HatesFire => true;
    public override int PackSort => 8;
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override Realm? ToRealm => SaveGame.SingletonRepository.Realms.Get<LifeRealm>();
}
