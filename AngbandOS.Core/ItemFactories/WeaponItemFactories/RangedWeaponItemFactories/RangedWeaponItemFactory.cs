// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class RangedWeaponItemFactory : WeaponItemFactory
{
    public override void ApplySlayingForRandomArtifactCreation(ItemCharacteristics characteristics)
    {
        if (characteristics.ArtifactBias != null)
        {
            if (characteristics.ArtifactBias.ApplySlaying(characteristics))
            {
                return;
            }
        }

        switch (Game.DieRoll(6))
        {
            case 1:
            case 2:
            case 3:
                characteristics.XtraMight = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;

            default:
                characteristics.XtraShots = true;
                if (characteristics.ArtifactBias == null && Game.DieRoll(9) == 1)
                {
                    characteristics.ArtifactBias = Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
                }
                break;
        }
    }
    public RangedWeaponItemFactory(Game game) : base(game) { }

}
