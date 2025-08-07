// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class CloakOfTheSwashbucklerFixedArtifact : FixedArtifact
{
    private CloakOfTheSwashbucklerFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(ClothCloakItemFactory);
    public override ColorEnum Color => ColorEnum.Green;
    public override string Name => "The Cloak of the Swashbuckler";
    public override int Dd => 0;
    public override int Ds => 0;
    public override int Level => 10;
    public override int Rarity => 90;
    public override int ToA => 18;
    public override int ToD => 0;
    public override int ToH => 0;
}
