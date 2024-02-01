// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class GemstoneShiningTrapezodedronFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private GemstoneShiningTrapezodedronFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(GemstoneLightSourceItemFactory);

    // Shining Trapezohedron lights the entire level and recalls us, but drains
    // health to do so
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("The gemstone flashes bright red!");
        SaveGame.RunScript(nameof(WizardLightScript));
        SaveGame.MsgPrint("The gemstone drains your vitality...");
        SaveGame.TakeHit(base.SaveGame.Rng.DiceRoll(3, 8), "the Gemstone 'Trapezohedron'");
        SaveGame.DetectTraps();
        SaveGame.DetectDoors();
        SaveGame.DetectStairs();
        if (SaveGame.GetCheck("Activate recall? "))
        {
            SaveGame.RunScript(nameof(ToggleRecallScript));
        }
        item.RechargeTimeLeft = base.SaveGame.Rng.RandomLessThan(20) + 20;
    }
    public string DescribeActivationEffect() => "clairvoyance and recall, draining you";

    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "The Gemstone 'Shining Trapezodedron'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 150000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "'Shining Trapezodedron'";
    public override bool HasOwnType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool ResChaos => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
    public override bool Wis => true;
}
