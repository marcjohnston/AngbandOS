// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ReferenceItemPropertyFactory<T> : ItemPropertyFactory where T : class
{
    public override ItemProperty Instantiate()
    {
        return new NullableReferenceItemProperty<T>(Index); // References are always nullable.  They cannot participate in the override process.
    }
    public override ItemProperty InstantiateNullable()
    {
        return new NullableReferenceItemProperty<T>(Index);
    }
    public ReferenceItemPropertyFactory(int index) : base(index) { }
}
