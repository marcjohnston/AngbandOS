// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfMagicFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private RingOfMagicFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<BarahirRingItemFactory>();
    }


    // Ring of Magic has a djinn in it that drains life from an opponent
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("You order Frakir to strangle your opponent.");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        if (saveGame.DrainLife(dir, 100))
        {
            item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(100) + 100;
        }
    }
    public string DescribeActivationEffect() => "a strangling attack (100) every 100+d100 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<EqualSignSymbol>();
    public override string Name => "The Ring of Magic";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 75000;
    public override int Dd => 0;
    public override bool Dex => true;
    public override int Ds => 0;
    public override string FriendlyName => "of Magic";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 50;
    public override int Pval => 1;
    public override int Rarity => 25;
    public override bool ResPois => true;
    public override bool Search => true;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 2;
    public override bool Wis => true;
}