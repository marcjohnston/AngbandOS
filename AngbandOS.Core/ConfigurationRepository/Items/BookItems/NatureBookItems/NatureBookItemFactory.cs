﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class NatureBookItemFactory : BookItemFactory
{
    public NatureBookItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<NatureSpellBooksItemClass>();
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.NatureBook;

    public override int PackSort => 6;
    public override bool HatesFire => true;
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override Realm? ToRealm => SaveGame.SingletonRepository.Realms.Get<NatureRealm>();
}