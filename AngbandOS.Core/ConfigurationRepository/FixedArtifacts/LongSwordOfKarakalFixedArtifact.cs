// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfKarakalFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private LongSwordOfKarakalFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<SwordLongSword>();
    }


    // Karakal teleports you randomly
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        switch (SaveGame.Rng.DieRoll(13))
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                saveGame.TeleportPlayer(10);
                break;

            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                saveGame.TeleportPlayer(222);
                break;

            case 11:
            case 12:
                saveGame.StairCreation();
                break;

            default:
                if (saveGame.GetCheck("Leave this level? "))
                {
                    {
                        saveGame.DoCmdSaveGame(true);
                    }
                    saveGame.NewLevelFlag = true;
                    saveGame.CameFrom = LevelStart.StartRandom;
                }
                break;
        }
        item.RechargeTimeLeft = 35;
    }
    public string DescribeActivationEffect() => "a getaway every 35 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Long Sword of Karakal";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Blows => true;
    public override bool BrandElec => true;
    public override bool Chaotic => true;
    public override bool Con => true;
    public override int Cost => 150000;
    public override int Dd => 2;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Karakal";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override bool Lightsource => true;
    public override int Pval => 2;
    public override int Rarity => 30;
    public override bool Regen => true;
    public override bool ResDark => true;
    public override bool ResDisen => true;
    public override bool ResElec => true;
    public override bool ResFear => true;
    public override bool ResLight => true;
    public override bool SeeInvis => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayEvil => true;
    public override bool SlowDigest => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustCon => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 12;
    public override int ToH => 8;
    public override int Weight => 130;
}