// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class LongSwordOfTheDawnFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private LongSwordOfTheDawnFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<SwordLongSword>();
    }

    // Dawn Sword summons a reaver
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your sword flickers black for a moment...");
        saveGame.SummonSpecificFriendly(saveGame.MapY, saveGame.MapX, saveGame.Difficulty, new ReaverMonsterSelector(), true);
        item.RechargeTimeLeft = 500 + Program.Rng.DieRoll(500);
    }
    public string DescribeActivationEffect() => "summon a Black Reaver every 500+d500 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<VerticalBarSymbol>();
    public override ColourEnum Colour => ColourEnum.BrightWhite;
    public override string Name => "The Long Sword of the Dawn";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override bool Cha => true;
    public override int Cost => 250000;
    public override int Dd => 3;
    public override int Ds => 5;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dawn";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override int Level => 40;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 120;
    public override bool Regen => true;
    public override bool ResBlind => true;
    public override bool ResFear => true;
    public override bool ResFire => true;
    public override bool ResLight => true;
    public override bool ShowMods => true;
    public override bool SlayDemon => true;
    public override bool SlayDragon => true;
    public override bool SlayEvil => true;
    public override bool SlayUndead => true;
    public override bool SustCha => true;
    public override int ToA => 0;
    public override int ToD => 20;
    public override int ToH => 20;
    public override bool Vorpal => true;
    public override int Weight => 130;
}
