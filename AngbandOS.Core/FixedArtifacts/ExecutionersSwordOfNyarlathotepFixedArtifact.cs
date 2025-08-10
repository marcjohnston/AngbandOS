// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class ExecutionersSwordOfNyarlathotepFixedArtifact : FixedArtifact
{
    private ExecutionersSwordOfNyarlathotepFixedArtifact(Game game) : base(game) { }
    protected override string BaseItemFactoryName => nameof(ExecutionersSwordWeaponItemFactory);
    public override ColorEnum Color => ColorEnum.Red;
    public override string Name => "The Executioner's Sword of Nyarlathotep";
    public override int Level => 40;
    public override int Rarity => 15;
    public override int ToA => 0;
    public override int ToD => 19;
    public override int ToH => 18;
}
