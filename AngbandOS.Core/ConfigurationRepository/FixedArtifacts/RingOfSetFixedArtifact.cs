// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FixedArtifacts;

[Serializable]
internal class RingOfSetFixedArtifact : FixedArtifact, IFixedArtifactActivatible
{
    private ItemFactory _baseItemCategory;
    private RingOfSetFixedArtifact(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        _baseItemCategory = SaveGame.SingletonRepository.ItemFactories.Get<PowerRingItemFactory>();
    }


    // Ring of Set has a random effect
    public void ActivateItem(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("The ring glows intensely black...");
        if (!saveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        RingOfSetPower(dir);
        item.RechargeTimeLeft = SaveGame.Rng.RandomLessThan(450) + 450;
    }
    public string DescribeActivationEffect() => "bizarre things every 450+d450 turns";
    public override void ApplyResistances(SaveGame saveGame, Item item)
    {
        item.BonusPowerType = RareItemTypeEnum.SpecialAbility;
        item.BonusPowerSubType= SaveGame.SingletonRepository.Activations.ToWeightedRandom().Choose();

        IArtifactBias artifactBias = null;
        item.ApplyRandomResistance(ref artifactBias, SaveGame.Rng.DieRoll(22) + 16);
    }
    public override ItemFactory BaseItemCategory => _baseItemCategory;

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(EqualSignSymbol));
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override string Name => "The Ring of Set";
    public override int Ac => 0;
    public override bool Activate => true;
    public override bool Aggravate => true;
    public override bool Cha => true;
    public override bool Con => true;
    public override int Cost => 5000000;
    public override bool Cursed => true;
    public override int Dd => 1;
    public override bool Dex => true;
    public override bool DrainExp => true;
    public override bool DreadCurse => true;
    public override int Ds => 1;
    public override string FriendlyName => "of Set";
    public override bool HasOwnType => true;
    public override bool HeavyCurse => true;
    public override bool HideType => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool ImAcid => true;
    public override bool ImCold => true;
    public override bool ImElec => true;
    public override bool ImFire => true;
    public override bool InstaArt => true;
    public override bool Int => true;
    public override int Level => 100;
    public override bool PermaCurse => true;
    public override int Pval => 5;
    public override int Rarity => 100;
    public override bool Regen => true;
    public override bool SeeInvis => true;
    public override bool Speed => true;
    public override bool Str => true;
    public override bool SustCha => true;
    public override bool SustCon => true;
    public override bool SustDex => true;
    public override bool SustInt => true;
    public override bool SustStr => true;
    public override bool SustWis => true;
    public override int ToA => 0;
    public override int ToD => 15;
    public override int ToH => 15;
    public override int Weight => 2;
    public override bool Wis => true;

    /// <summary>
    /// Invoke a random power from the Ring of Set
    /// </summary>
    /// <param name="direction"> The direction the player is aiming </param>
    private void RingOfSetPower(int direction)
    {
        switch (SaveGame.Rng.DieRoll(10))
        {
            case 1:
            case 2:
                {
                    // Decrease all the players ability scores, bypassing sustain and divine protection
                    SaveGame.MsgPrint("You are surrounded by a malignant aura.");
                    SaveGame.DecreaseAbilityScore(Ability.Strength, 50, true);
                    SaveGame.DecreaseAbilityScore(Ability.Intelligence, 50, true);
                    SaveGame.DecreaseAbilityScore(Ability.Wisdom, 50, true);
                    SaveGame.DecreaseAbilityScore(Ability.Dexterity, 50, true);
                    SaveGame.DecreaseAbilityScore(Ability.Constitution, 50, true);
                    SaveGame.DecreaseAbilityScore(Ability.Charisma, 50, true);
                    // Reduce both experience and maximum experience
                    SaveGame.ExperiencePoints -= SaveGame.ExperiencePoints / 4;
                    SaveGame.MaxExperienceGained -= SaveGame.ExperiencePoints / 4;
                    SaveGame.CheckExperience();
                    break;
                }
            case 3:
                {
                    // Dispel monsters
                    SaveGame.MsgPrint("You are surrounded by a powerful aura.");
                    SaveGame.DispelMonsters(1000);
                    break;
                }
            case 4:
            case 5:
            case 6:
                {
                    // Do a 300 damage mana ball
                    SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), direction, 300, 3);
                    break;
                }
            case 7:
            case 8:
            case 9:
            case 10:
                {
                    // Do a 250 damage mana bolt
                    SaveGame.FireBolt(SaveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), direction, 250);
                    break;
                }
        }
    }

}
