﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpriteMalePhysicalAttributeSet : PhysicalAttributeSetGameConfiguration
{
    public override int BaseHeight => 32;
    public override int HeightRange => 2;
    public override int BaseWeight => 75;
    public override int WeightRange => 2;
}
