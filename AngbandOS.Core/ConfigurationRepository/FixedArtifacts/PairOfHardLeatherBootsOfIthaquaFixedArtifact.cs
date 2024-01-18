// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class PairOfHardLeatherBootsOfIthaquaFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private PairOfHardLeatherBootsOfIthaquaFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<HardLeatherBootsArmorItemFactory>();
    }


    // Boots haste you
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("A wind swirls around your boots...");
        if (saveGame.TimedHaste.TurnsRemaining == 0)
        {
            saveGame.TimedHaste.SetTimer(SaveGame.Rng.DieRoll(20) + 20);
        }
        else
        {
            saveGame.TimedHaste.AddTimer(5);
        }
        item.RechargeTimeLeft = 200;
    }
    public string DescribeActivationEffect() => "haste self (20+d20 turns) every 200 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(CloseBraceSymbol));
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "The Pair of Hard Leather Boots of Ithaqua";
    public override int Ac => 3;
    public override bool Activate => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Ithaqua";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override int Pval => 15;
    public override int Rarity => 120;
    public override bool ResNexus => true;
    public override bool Speed => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 40;
}
