// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ShadowCloakOfTheShoggothFixedArtifact : FixedArtifact
{
    private readonly ItemFactory _baseItemCategory;
    private ShadowCloakOfTheShoggothFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<ShadowCloakArmorItemFactory>();
    }

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<OpenParenthesisSymbol>();
    public override ColourEnum Colour => ColourEnum.Black;
    public override string Name => "The Shadow Cloak of the Shoggoth";
    public override int Ac => 6;
    public override int Cost => 35000;
    public override int Dd => 0;
    public override int Ds => 0;
    public override bool FreeAct => true;
    public override string FriendlyName => "of the Shoggoth";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override int Level => 40;
    public override int Pval => 4;
    public override int Rarity => 40;
    public override bool SeeInvis => true;
    public override bool Stealth => true;
    public override int ToA => 12;
    public override int ToD => 0;
    public override int ToH => 0;
    public override int Weight => 5;
}
