// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class SetOfGauntletsIronfistFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private SetOfGauntletsIronfistFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<GauntletGlovesArmorItemFactory>();
    }


    // Iron Fist shoots fire bolts
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your gauntlets are covered in fire...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, SaveGame.Rng.DiceRoll(9, 8));
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(8) + 8;
    }
    public string DescribeActivationEffect() => "fire bolt (9d8) every 8+d8 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<CloseBraceSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    public override string Name => "The Set of Gauntlets 'Ironfist'";
    public override int Ac => 2;
    public override bool Activate => true;
    public override int Cost => 15000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "'Ironfist'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 10;
    public override int Pval => 0;
    public override int Rarity => 20;
    public override bool ResFire => true;
    public override int ToA => 15;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 25;
}