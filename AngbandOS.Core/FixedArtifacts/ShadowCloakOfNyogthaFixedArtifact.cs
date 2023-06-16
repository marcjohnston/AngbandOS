// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ShadowCloakOfNyogthaFixedArtifact : FixedArtifact, IActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private ShadowCloakOfNyogthaFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<ShadowCloakArmorItemFactory>();
    }

    // Nyogtha restores experience
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your cloak glows a deep red...");
        saveGame.Player.RestoreLevel();
        item.RechargeTimeLeft = 450;
    }
    public string DescribeActivationEffect() => "restore life levels every 450 turns";
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '(';
    public override Colour Colour => Colour.Black;
    public override string Name => "The Shadow Cloak of Nyogtha";
    public override int Ac => 6;
    public override bool Activate => true;
    public override bool Cha => true;
    public override int Cost => 55000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of Nyogtha";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Int => true;
    public override int Level => 40;
    public override int Pval => 2;
    public override int Rarity => 40;
    public override bool ResAcid => true;
    public override bool ResCold => true;
    public override bool ResFire => true;
    public override bool Speed => true;
    public override bool Stealth => true;
    public override int ToA => 20;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
    public override bool Wis => true;
}
