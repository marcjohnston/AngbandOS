// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfSoftLeatherBootsOfDancingFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private PairOfSoftLeatherBootsOfDancingFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SoftLeatherBootsArmorItemFactory>();
    }


    // Dancing heal poison and fear
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your boots glow deep blue...");
        saveGame.TimedFear.ResetTimer();
        saveGame.TimedPoison.ResetTimer();
        item.RechargeTimeLeft = 5;
    }
    public string DescribeActivationEffect() => "remove fear and cure poison every 5 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "The Pair of Soft Leather Boots of Dancing";
    public override int Ac => 2;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 40000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 1;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Dancing";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 5;
    public override int Rarity => 25;
    public override bool ResChaos => true;
    public override bool ResNether => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 20;
}
