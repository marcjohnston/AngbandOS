namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HeavilyCursedItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool?[] DesiredValue)[]? BoolAttributeFilterBindings => new (string, bool?[])[] { (nameof(IsCursedAttribute), new bool?[] { true }), (nameof(HeavyCurseAttribute), new bool?[] { true }) };
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(PermaCurseAttribute), false) };
        public override string[] EffectDescription => new string[] { "It is heavily cursed." };
    }
}