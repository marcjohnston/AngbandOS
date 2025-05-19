// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.PhysicalAttributeSets;

[Serializable]
internal class HalfGiantFemalePhysicalAttributeSet : PhysicalAttributeSet
{
    private HalfGiantFemalePhysicalAttributeSet(Game game) : base(game) { }
    public override int BaseHeight => 80;
    public override int HeightRange => 10;
    public override int BaseWeight => 240;
    public override int WeightRange => 64;
}
