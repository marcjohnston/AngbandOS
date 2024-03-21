// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class SorceryBookItemFactory : BookItemFactory
{
    public SorceryBookItemFactory(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Returns just the realm name because Sorcery automatically assumes magic--so we omit the "Magic" suffix from the divine title.
    /// </summary>
    public override string DivineTitle => RealmName;
    public override string RealmName => "Sorcery";
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(SorcerySpellBooksItemClass));
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.SorceryBook;
    public override bool HatesFire => true;
    public override int PackSort => 7;
    public override ColorEnum Color => ColorEnum.BrightBlue;
}
