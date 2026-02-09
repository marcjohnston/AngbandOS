namespace AngbandOS.Core;
    [Serializable]
internal class SlayAnimalAttribute : OrAttribute
{
    private SlayAnimalAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayAnimal;
}