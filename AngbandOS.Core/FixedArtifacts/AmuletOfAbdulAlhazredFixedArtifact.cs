// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AmuletOfAbdulAlhazredFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private AmuletOfAbdulAlhazredFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<IngweAmuletJeweleryItemFactory>();
    }

    // Amulet of Abdul Alhazred dispels evil
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The amulet floods the area with goodness...");
        saveGame.DispelEvil(saveGame.Player.Level * 5);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
    }
    public string DescribeActivationEffect() => "dispel evil (x5) every 300+d300 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '"';
    public override string Name => "The Amulet of Abdul Alhazred";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 90000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of Abdul Alhazred";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override int Level => 65;
    public override int Pval => 3;
    public override int Rarity => 30;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResElec => true;
    public override bool SeeInvis => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
    public override bool Wis => true;
}
