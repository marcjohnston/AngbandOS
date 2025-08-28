// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ReferenceAttributeFactory<T> : AttributeFactory where T : class
{
    public override AttributeValue Instantiate() => new NullableReferenceAttributeValue<T>(this, null); // This would normally be the non-nullable version, but there is no such thing for a reference type.
    public ReferenceAttributeFactory(AttributeEnum index) : base(index) { }
}
