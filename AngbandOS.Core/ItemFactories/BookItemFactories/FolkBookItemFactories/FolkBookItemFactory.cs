// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class FolkBookItemFactory : BookItemFactory
{
    public FolkBookItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.ItemClasses.Get(nameof(FolkSpellBooksItemClass));
    public override string RealmName => "Folk";
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.FolkBook;
    public override int PackSort => 2;
    public override bool HatesFire => true;
    public override ColorEnum Color => ColorEnum.BrightPurple;
}
