// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class LightSourceItem : ArmorItem
{
    public LightSourceItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

    /// <summary>
    /// Returns the factory that created this light source item.
    /// </summary>
    public override LightSourceItemFactory Factory => (LightSourceItemFactory)base.Factory;

    public override string Identify()
    {
        if (FixedArtifact != null)
        {
            return "It provides light (radius 3) forever.";
        }
        else
        {
            string burnRate = Factory.BurnRate == 0 ? "forever" : "when fueled";
            return $"It provides light (radius {Factory.Radius}) {burnRate}.";
        }
    }

    public override int? GetTypeSpecificRealValue(int value)
    {
        return ComputeTypeSpecificRealValue(value);
    }
    public override int GetAdditionalMassProduceCount()
    {
        int cost = Value();
        if (cost <= 5)
        {
            return MassRoll(3, 5);
        }
        if (cost <= 20)
        {
            return MassRoll(3, 5);
        }
        return 0;
    }

    public override string GetVerboseDescription()
    {
        string s = "";
        if (Factory.BurnRate > 0)
        {
            s += $" (with {TypeSpecificValue} {Pluralize("turn", TypeSpecificValue)} of light)";
        }
        s += base.GetVerboseDescription();
        return s;
    }
}