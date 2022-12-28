using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class KatanaOfGrooFixedArtifact : BaseFixedArtifact
{
    private readonly ItemClass _baseItemCategory;
    private KatanaOfGrooFixedArtifact(SaveGame saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemCategories.Get<SwordKatana>();
    }

    public override ItemClass BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Katana of Groo";
    public override int Ac => 0;
    public override bool Blows => true;
    public override int Cost => 75000;
    public override int Dd => 8;
    public override bool Dex => true;
    public override int Ds => 4;
    public override FixedArtifactId FixedArtifactID => FixedArtifactId.KatanaOfGroo;
    public override string FriendlyName => "of Groo";
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 30;
    public override int Pval => 3;
    public override int Rarity => 25;
    public override bool ShowMods => true;
    public override bool Speed => true;
    public override bool SustDex => true;
    public override int ToA => 0;
    public override int ToD => 0;
    public override int ToH => 0;
    public override bool Vorpal => true;
    public override int Weight => 50;
}
