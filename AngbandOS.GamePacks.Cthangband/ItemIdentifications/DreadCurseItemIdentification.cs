namespace AngbandOS.GamePacks.Cthangband
{
    public class DreadCurseItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(DreadCurseItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It carries an ancient foul curse." };
    }
}