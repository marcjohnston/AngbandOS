// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BrassLanternLightSourceItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool EasyKnow => true;
    public override bool IgnoreFire => true;
    public override int Radius => 2;
    public override int Weight => 50;
    public override int Value => 35;
    public override int DamageDice => 1;
    public override int DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
}
