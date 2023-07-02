// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class NecklaceOfTheDwarvesFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private NecklaceOfTheDwarvesFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<NecklaceAmuletJeweleryItemFactory>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<DoubleQuoteSymbol>();
    public override string Name => "The Necklace of the Dwarves";
    public override int Ac => 0;
    public override bool Con => true;
    public override int Cost => 75000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Dwarves";
    public override bool HasOwnType => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool Infra => true;
    public override bool InstaArt => true;
    public override int Level => 70;
    public override bool Lightsource => true;
    public override int Pval => 3;
    public override int Rarity => 50;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool Str => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 3;
}
