// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class MithrilChainMailOfTheVampireHunterFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private MithrilChainMailOfTheVampireHunterFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<MithrilChainMailHardArmorItemFactory>();
    }


    // Vampire Hunter cures most ailments
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("A heavenly choir sings...");
        saveGame.TimedPoison.ResetTimer();
        saveGame.TimedBleeding.ResetTimer();
        saveGame.TimedStun.ResetTimer();
        saveGame.TimedConfusion.ResetTimer();
        saveGame.TimedBlindness.ResetTimer();
        saveGame.TimedHeroism.AddTimer(SaveGame.Rng.DieRoll(25) + 25);
        saveGame.RestoreHealth(777);
        item.RechargeTimeLeft = 300;
    }
    public string DescribeActivationEffect() => "heal (777), curing and heroism every 300 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBlue;
    public override string Name => "The Mithril Chain Mail of the Vampire Hunter";
    public override int Ac => 28;
    public override bool Activate => true;
    public override int Cost => 135000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "of the Vampire Hunter";
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 3;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResDark => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResNether => true;
    public override bool ResPois => true;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => -1;
    public override int Weight => 150;
    public override bool Wis => true;
}