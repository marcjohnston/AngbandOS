// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ScimitarSoulswordFixedArtifact : FixedArtifact
{
    private ScimitarSoulswordFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(ScimitarWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.BrightWhite;
    public override string Name => "The Scimitar 'Soulsword'";
    public override int Cost => 111111;
    public override int Dd => 2;
    public override int Ds => 5;
    public override int Level => 20;
    public override int Rarity => 8;
    public override int ToA => 0;
    public override int ToD => 11;
    public override int ToH => 9;
    public override int Weight => 130;
}
