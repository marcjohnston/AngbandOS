// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DragonHelmOfPowerFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private DragonHelmOfPowerFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<HelmDragonHelm>();
    }


    // Dragon Helm and Terror Mask cause fear
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.TurnMonsters(40 + saveGame.ExperienceLevel);
        item.RechargeTimeLeft = 3 * (saveGame.ExperienceLevel + 10);
    }
    public string DescribeActivationEffect() => "rays of fear in every direction";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightGreen;
    public override string Name => "The Dragon Helm of Power";
    public override int Ac => 8;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 300000;
    public override int Dd => 1;
    public override bool Dex => true;
    public override int Ds => 3;
    public override string FriendlyName => "of Power";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 40;
    public override bool Lightsource => true;
    public override int Pval => 4;
    public override int Rarity => 12;
    public override bool ResAcid => true;
    public override bool ResBlind => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override bool Telepathy => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 75;
}