// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ItemMatches;

[Serializable]
internal class OrAttributeItemMatch : ItemMatch
{
    public readonly Attribute Attribute;
    public readonly bool DesiredValue;
    public OrAttributeItemMatch(Game game, Attribute attribute, bool desiredValue) : base(game, $"{nameof(OrAttributeItemMatch)},{attribute.GetType().Name},{desiredValue}")
    {
        Attribute = attribute;
        DesiredValue = desiredValue;
    }
    public override bool Matches(Item item)
    {
        bool value = item.EffectivePropertySet.Get<OrEffectiveAttributeValue>(Attribute).Get();
        return value == DesiredValue;
    }
}