// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class StarEssenceOfXothFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private StarEssenceOfXothFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Bind()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get(nameof(StarEssenceElendilLightSourceItemFactory));
    }


    // Star essence of Xoth lights and maps the area
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The essence shines brightly...");
        saveGame.MapArea();
        saveGame.LightArea(SaveGame.Rng.DiceRoll(2, 15), 3);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(50) + 50;
    }
    public string DescribeActivationEffect() => "magic mapping and light every 50+d50 turns";
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(AsteriskSymbol));
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "The Star Essence of Xoth";
    public override int Ac => 0;
    public override bool Activate => true;
    public override int Cost => 32500;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "of Xoth";
    public override bool HasOwnType => true;
    public override bool HoldLife => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool InstaArt => true;
    public override int Level => 30;
    public override int Pval => 1;
    public override int Rarity => 25;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
}
