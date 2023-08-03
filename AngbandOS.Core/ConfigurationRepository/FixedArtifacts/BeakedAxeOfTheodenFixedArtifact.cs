// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class BeakedAxeOfTheodenFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private BeakedAxeOfTheodenFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<PolearmBeakedAxe>();
    }


    // Theoden drains life
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your axe blade glows black...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.DrainLife(dir, 120);
        item.RechargeTimeLeft = 400;
    }
    public string DescribeActivationEffect() => "drain life (120) every 400 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ForwardSlashSymbol>();
    public override ColourEnum Colour => ColourEnum.Grey;
    public override string Name => "The Beaked Axe of Theoden";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 40000;
    public override int Dd => 2;
    public override int Ds => 6;
    public override string FriendlyName => "of Theoden";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 20;
    public override int Pval => 3;
    public override int Rarity => 15;
    public override bool ShowMods => true;
    public override bool SlayDragon => true;
    public override bool SlowDigest => true;
    public override bool Telepathy => true;
    public override int ToA => 0;
    public override int ToD => 10;
    public override int ToH => 8;
    public override int Weight => 180;
    public override bool Wis => true;
}
