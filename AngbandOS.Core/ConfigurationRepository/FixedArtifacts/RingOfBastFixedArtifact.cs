// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfBastFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private RingOfBastFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    protected override string BaseItemFactoryName => nameof(TulkasRingItemFactory);

    // Ring of Bast hastes you
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("The ring glows brightly...");
        if (SaveGame.TimedHaste.TurnsRemaining == 0)
        {
            SaveGame.TimedHaste.SetTimer(base.SaveGame.DieRoll(75) + 75);
        }
        else
        {
            SaveGame.TimedHaste.AddTimer(5);
        }
        item.RechargeTimeLeft = base.SaveGame.RandomLessThan(150) + 150;
    }
    public string DescribeActivationEffect => "haste self (75+d75 turns) every 150+d150 turns";

    public override string Name => "The Ring of Bast";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 175000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override string FriendlyName => "of Bast";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    public override int Pval => 4;
    public override int Rarity => 50;
    public override bool Speed => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 2;
}
