// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class IntAttributeFactory : AttributeFactory
{
    public override AttributeValue Instantiate() => new IntAttributeValue(0);
    public override NullableAttributeValue InstantiateNullable() => new NullableIntAttributeValue(null);
    public IntAttributeFactory(AttributeEnum index) : base(index) { }
}
