// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ReferencePropertyFactory<T> : PropertyFactory where T : class
{
    public override PropertyValue Instantiate()
    {
        return new NullableReferencePropertyValue<T>(null); // This would normally be the non-nullable version, but there is no such thing for a reference type.
    }
    public override NullablePropertyValue InstantiateNullable() => new NullableReferencePropertyValue<T>(null);

    public ReferencePropertyFactory(int index) : base(index) { }
}
