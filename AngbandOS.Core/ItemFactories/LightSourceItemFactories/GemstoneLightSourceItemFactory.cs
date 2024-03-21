// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class GemstoneLightSourceItemFactory : LightSourceItemFactory
{
    private GemstoneLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override void EquipmentProcessWorldHook()
    {
        if (Game.DieRoll(999) == 1 && !Game.HasAntiMagic)
        {
            if (Game.InvulnerabilityTimer.Value == 0)
            {
                Game.MsgPrint("The Jewel of Judgement drains life from you!");
                Game.TakeHit(Math.Min(Game.ExperienceLevel.Value, 50), "the Jewel of Judgement");
            }
        }
    }
    public override Symbol Symbol => Game.SingletonRepository.Symbols.Get(nameof(AsteriskSymbol));
    public override ColorEnum Color => ColorEnum.Diamond;
    public override string Name => "Gemstone";

    public override int Cost => 60000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "& Gemstone~"; // TODO: This appears to cause a defect in identification
    public override bool InstaArt => true;
    public override int LevelNormallyFound => 60;
    public override int Weight => 5;

    public override bool ProvidesSunlight => true;

    public override Item CreateItem() => new Item(Game, this);
}
