namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class DreadCurseItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(DreadCurseAttribute), true) };
        public override string[] EffectDescription => new string[] { "It carries an ancient foul curse." };
    }
}