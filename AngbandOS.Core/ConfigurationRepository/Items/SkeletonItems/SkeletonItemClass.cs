﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class SkeletonItemClass : ItemFactory
{
    public SkeletonItemClass(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get<SkeletonsItemClass>();
    public override bool EasyKnow => true;
    public override int PackSort => 40;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Skeleton;
    public override bool HatesAcid => true;

    public override ColourEnum Colour => ColourEnum.Beige;
}