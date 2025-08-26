namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RestoreConstitutionMushroomFoodItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override int Weight => 1;
    public override int Value => 350;
    public override ColorEnum Color => ColorEnum.Green;
}
