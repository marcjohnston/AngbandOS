// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class DaggerFaithFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private readonly ItemFactory _baseItemCategory;
    private DaggerFaithFixedArtifact(SaveGame saveGame) : base(saveGame)
    {
        _baseItemCategory = saveGame.SingletonRepository.ItemFactories.Get<SwordDagger>();
    }

    // Faith shoots a fire bolt
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your dagger is covered in fire...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        saveGame.FireBolt(saveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), dir, Program.Rng.DiceRoll(9, 8));
        item.RechargeTimeLeft = Program.Rng.RandomLessThan(8) + 8;
    }

    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
    }
    public string DescribeActivationEffect() => "fire bolt (9d8) every 8+d8 turns";

    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override char Character => '|';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "The Dagger 'Faith'";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool BrandFire => true;
    public override int Cost => 12000;
    public override int Dd => 1;
    public override int Ds => 4;
    public override string FriendlyName => "'Faith'";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 4;
    public override bool Lightsource => true;
    public override int Pval => 0;
    public override int Rarity => 10;
    public override bool ResFire => true;
    public override bool ShowMods => true;
    public override int ToA => 0;
    public override int ToD => 6;
    public override int ToH => 4;
    public override int Weight => 12;
}
