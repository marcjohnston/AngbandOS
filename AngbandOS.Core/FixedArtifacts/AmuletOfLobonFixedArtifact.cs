// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class AmuletOfLobonFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private AmuletOfLobonFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<CarlammasAmuletJeweleryItemFactory>();
    }

    // Amulet of Lobon protects us from evil
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The amulet lets out a shrill wail...");
        int k = 3 * saveGame.Player.ExperienceLevel;
        saveGame.Player.TimedProtectionFromEvil.AddTimer(Program.Rng.DieRoll(25) + k);
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
    }
    public string DescribeActivationEffect() => "protection from evil every 225+d225 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DoubleQuoteSymbol>();
    public override string Name => "The Amulet of Lobon";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Con => true;
    public override int Cost => 60000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override string FriendlyName => "of Lobon";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 50;
    public override int Pval => 2;
    public override int Rarity => 10;
    public override bool ResFire => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
}
