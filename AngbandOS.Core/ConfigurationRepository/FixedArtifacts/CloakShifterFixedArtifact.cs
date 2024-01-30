// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakShifterFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private CloakShifterFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(ClothCloakCloakArmorItemFactory));
    }


    // Shifter teleports you
    public void ActivateItem(Item item)
    {
        SaveGame.MsgPrint("Your cloak twists space around you...");
        SaveGame.RunScriptInt(nameof(TeleportSelfScript), 100);
        item.RechargeTimeLeft = 45;
    }
    public string DescribeActivationEffect() => "teleport every 45 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(OpenParenthesisSymbol));
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "The Cloak 'Shifter'";
    public override int Ac => 1;
    public override bool Activate => true;
    public override int Cost => 11000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "'Shifter'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 3;
    public override int Pval => 3;
    public override int Rarity => 10;
    public override bool ResAcid => true;
    public override bool Stealth => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 10;
}
