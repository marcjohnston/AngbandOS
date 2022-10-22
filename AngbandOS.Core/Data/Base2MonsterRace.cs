using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.StaticData
{
    internal abstract class Base2MonsterRace
    {
        /// <summary>
        /// The column from which to take the graphical tile.
        /// </summary>
        public abstract char Character { get; }

        /// <summary>
        /// The row from which to take the graphical tile
        /// </summary>
        public virtual Colour Colour => Colour.White;

        /// <summary>
        /// A unique identifier for the entity
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// The monster can cast acid balls.
        /// </summary>
        public virtual bool AcidBall => false;

        /// <summary>
        /// The monster can cast acid bolts
        /// </summary>
        public virtual bool AcidBolt => false;

        /// <summary>
        /// The monster is an animal.
        /// </summary>
        public virtual bool Animal => false;

        /// <summary>
        /// The monsters armour class.
        /// </summary>
        public abstract int ArmourClass { get; }

        /// <summary>
        /// The monster shoots arrows for 1d6 damage.
        /// </summary>
        public virtual bool Arrow1D6 => false;

        /// <summary>
        /// The monster shoots arrows for 3d6 damage.
        /// </summary>
        public virtual bool Arrow3D6 => false;

        /// <summary>
        /// The monster shoots missiles for 5d6 damage.
        /// </summary>
        public virtual bool Arrow5D6 => false;

        /// <summary>
        /// The monster shoots missiles for 7d6 damage.
        /// </summary>
        public virtual bool Arrow7D6 => false;

        /// <summary>
        /// The number of times per round the monster attacks.
        /// </summary>
        public MonsterAttack Attack1 = new MonsterAttack();

        /// <summary>
        /// The attack's number of damage dice.
        /// </summary>
        public abstract int Attack1DDice { get; }

        /// <summary>
        /// The attack's type of damage dice.
        /// </summary>
        public abstract int Attack1DSides { get; }

        /// <summary>
        /// The attack's effect.
        /// </summary>
        public abstract AttackEffect Attack1Effect { get; }

        /// <summary>
        /// The attack's described method.
        /// </summary>
        public abstract AttackType Attack1Type { get; }

        /// <summary>
        /// The number of times per round the monster attacks.
        /// </summary>
        public MonsterAttack Attack2 = new MonsterAttack();

        /// <summary>
        /// The attack's number of damage dice.
        /// </summary>
        public abstract int Attack2DDice { get; }

        /// <summary>
        /// The attack's type of damage dice.
        /// </summary>
        public abstract int Attack2DSides { get; }

        /// <summary>
        /// The attack's effect.
        /// </summary>
        public abstract AttackEffect Attack2Effect { get; }

        /// <summary>
        /// The attack's described method
        /// </summary>
        public abstract AttackType Attack2Type { get; }

        /// <summary>
        /// The number of times per round the monster attacks.
        /// </summary>
        public MonsterAttack Attack3 = new MonsterAttack();

        /// <summary>
        /// The attack's number of damage dice.
        /// </summary>
        public abstract int Attack3DDice { get; }

        /// <summary>
        /// The attack's type of damage dice.
        /// </summary>
        public abstract int Attack3DSides { get; }

        /// <summary>
        /// The attack's effect.
        /// </summary>
        public abstract AttackEffect Attack3Effect { get; }

        /// <summary>
        /// The attack's described method.
        /// </summary>
        public abstract AttackType Attack3Type { get; }

        /// <summary>
        /// The number of times per round the monster attacks.
        /// </summary>
        public MonsterAttack Attack4 = new MonsterAttack();

        /// <summary>
        /// The attack's number of damage dice.
        /// </summary>
        public abstract int Attack4DDice { get; }

        /// <summary>
        /// The attack's type of damage dice.
        /// </summary>
        public abstract int Attack4DSides { get; }

        /// <summary>
        /// The attack's effect.
        /// </summary>
        public abstract AttackEffect Attack4Effect { get; }

        /// <summary>
        /// The attack's described method.
        /// </summary>
        public abstract AttackType Attack4Type { get; }

        /// <summary>
        /// The monster's colour can be anything (if 'AttrMulti' is set).
        /// </summary>
        public virtual bool AttrAny => false;

        /// <summary>
        /// The monster is transparent.
        /// </summary>
        public virtual bool AttrClear => false;

        /// <summary>
        /// The monster changes colour.
        /// </summary>
        public virtual bool AttrMulti => false;

        /// <summary>
        /// The monster can break open doors.
        /// </summary>
        public virtual bool BashDoor => false;

        /// <summary>
        /// The monster can cast blindness.
        /// </summary>
        public virtual bool Blindness => false;

        /// <summary>
        /// The monster can cast blink.
        /// </summary>
        public virtual bool Blink => false;

        public virtual bool BrainSmash => false;

        public virtual bool BreatheAcid => false;

        public virtual bool BreatheChaos => false;

        public virtual bool BreatheCold => false;

        public virtual bool BreatheConfusion => false;

        public virtual bool BreatheDark => false;

        public virtual bool BreatheDisenchant => false;

        public virtual bool BreatheDisintegration => false;

        public virtual bool BreatheFire => false;

        public virtual bool BreatheForce => false;

        public virtual bool BreatheGravity => false;

        public virtual bool BreatheInertia => false;

        public virtual bool BreatheLight => false;

        public virtual bool BreatheLightning => false;

        public virtual bool BreatheMana => false;

        public virtual bool BreatheNether => false;

        public virtual bool BreatheNexus => false;

        public virtual bool BreathePlasma => false;

        public virtual bool BreathePoison => false;

        public virtual bool BreatheRadiation => false;

        public virtual bool BreatheShards => false;

        public virtual bool BreatheSound => false;

        public virtual bool BreatheTime => false;

        public virtual bool CauseCriticalWounds => false;

        public virtual bool CauseLightWounds => false;

        public virtual bool CauseMortalWounds => false;

        public virtual bool CauseSeriousWounds => false;

        /// <summary>
        /// The monster can cast chaos balls.
        /// </summary>
        public virtual bool ChaosBall => false;

        /// <summary>
        /// The monster is never seen, even with see invisible.
        /// </summary>
        public virtual bool CharClear => false;

        /// <summary>
        /// The monster is changes shape randomly.
        /// </summary>
        public virtual bool CharMulti => false;

        /// <summary>
        /// The monster can cast cold balls.
        /// </summary>
        public virtual bool ColdBall => false;

        public virtual bool ColdBlood => false;

        /// <summary>
        /// The monster can cast cold bolts.
        /// </summary>
        public virtual bool ColdBolt => false;

        public virtual bool Confuse => false;

        public virtual bool CreateTraps => false;

        public virtual bool Cthuloid => false;

        /// <summary>
        /// The monster can cast dark balls.
        /// </summary>
        public virtual bool DarkBall => false;

        public virtual bool Darkness => false;

        public virtual bool Demon => false;

        /// <summary>
        /// The descriptive text.
        /// </summary>
        public abstract string Description { get; }

        public virtual bool Dragon => false;

        public virtual bool DrainMana => false;

        public virtual bool DreadCurse => false;

        /// <summary>
        /// The monster drops 1d2 items.
        /// </summary>
        public virtual bool Drop_1D2 => false;

        /// <summary>
        /// The monster drops 2d2 items.
        /// </summary>
        public virtual bool Drop_2D2 => false;

        /// <summary>
        /// The monster drops 3d2 items.
        /// </summary>
        public virtual bool Drop_3D2 => false;

        /// <summary>
        /// The monster drops 4d2 items.
        /// </summary>
        public virtual bool Drop_4D2 => false;

        /// <summary>
        /// The monster drops an item 60% of the time.
        /// </summary>
        public virtual bool Drop60 => false;

        /// <summary>
        /// The monster drops an item 90% of the time.
        /// </summary>
        public virtual bool Drop90 => false;

        /// <summary>
        /// The monster drops good items.
        /// </summary>
        public virtual bool DropGood => false;

        /// <summary>
        /// The monster drops great items.
        /// </summary>
        public virtual bool DropGreat => false;

        public virtual bool EldritchHorror => false;

        public virtual bool EmptyMind => false;

        /// <summary>
        /// The monster comes with minions of the same character.
        /// </summary>
        public virtual bool Escorted => false;

        /// <summary>
        /// The monster's minions come in groups (this doesn't force minions if 'Escort' isn't set).
        /// </summary>
        public virtual bool EscortsGroup => false;

        public virtual bool Evil => false;

        /// <summary>
        /// The monster should use feminine pronouns.
        /// </summary>
        public virtual bool Female => false;

        /// <summary>
        /// The monster has an aura of fire around it.
        /// </summary>
        public virtual bool FireAura => false;

        /// <summary>
        /// The monster can cast fire balls.
        /// </summary>
        public virtual bool FireBall => false;

        /// <summary>
        /// The monster can cast fire bolts.
        /// </summary>
        public virtual bool FireBolt => false;

        /// <summary>
        /// The monster has maximum hit points.
        /// </summary>
        public virtual bool ForceMaxHp => false;

        /// <summary>
        /// The monster always starts asleep.
        /// </summary>
        public virtual bool ForceSleep => false;

        public virtual bool Forget => false;

        /// <summary>
        /// The 1-in-X frequency with which the monster uses special abilities.
        /// </summary>
        public abstract int FreqInate { get; }

        /// <summary>
        /// The 1-in-X frequency with which the monster uses spells.
        /// </summary>
        public abstract int FreqSpell { get; }

        /// <summary>
        /// The name that the game shows the player (may have duplicates).
        /// </summary>
        public abstract string FriendlyName { get; }

        /// <summary>
        /// The monster comes with friends of the same race.
        /// </summary>
        public virtual bool Friends => false;

        public virtual bool Giant => false;

        public virtual bool Good => false;

        public virtual bool GreatOldOne => false;

        public virtual bool Haste => false;

        /// <summary>
        /// The number of hit dice the monster has.
        /// </summary>
        public abstract int Hdice { get; }

        public virtual bool Heal => false;

        /// <summary>
        /// The number of hit points the monster has (click to update).
        /// </summary>
        public string HitPoints
        {
            get
            {
                if (ForceMaxHp)
                {
                    return $"{Hdice}d{Hside} (max. {Hdice * Hside})";
                }
                return $"{Hdice}d{Hside} (avg. {(Hdice * Hside / 2) + (Hdice / 2)})";
            }
        }

        public virtual bool Hold => false;

        /// <summary>
        /// The number of sides of the monster's hit dice.
        /// </summary>
        public abstract int Hside { get; }

        public virtual bool HurtByCold => false;

        public virtual bool HurtByFire => false;

        public virtual bool HurtByLight => false;

        public virtual bool HurtByRock => false;

        /// <summary>
        /// The monster can cast ice bolts.
        /// </summary>
        public virtual bool IceBolt => false;

        public virtual bool ImmuneAcid => false;

        public virtual bool ImmuneCold => false;

        public virtual bool ImmuneConfusion => false;

        public virtual bool ImmuneFear => false;

        public virtual bool ImmuneFire => false;

        public virtual bool ImmuneLightning => false;

        public virtual bool ImmunePoison => false;

        public virtual bool ImmuneSleep => false;

        public virtual bool ImmuneStun => false;

        public virtual bool Invisible => false;

        public virtual bool KillBody => false;

        public virtual bool KillItem => false;

        public virtual bool KillWall => false;

        /// <summary>
        /// The level on which the monster is normally found.
        /// </summary>
        public abstract int Level { get; }

        /// <summary>
        /// The monster has an aura of electricity around it.
        /// </summary>
        public virtual bool LightningAura => false;

        /// <summary>
        /// The monster can cast electricity balls.
        /// </summary>
        public virtual bool LightningBall => false;

        /// <summary>
        /// The monster can cast lightning bolts.
        /// </summary>
        public virtual bool LightningBolt => false;

        public virtual bool MagicMissile => false;

        public virtual bool Male => false;

        /// <summary>
        /// The monster can cast mana balls.
        /// </summary>
        public virtual bool ManaBall => false;

        /// <summary>
        /// The monster can cast mana bolts.
        /// </summary>
        public virtual bool ManaBolt => false;

        /// <summary>
        /// The experience value for killing one of these.
        /// </summary>
        public abstract int Mexp { get; }

        public virtual bool MindBlast => false;

        public virtual bool MoveBody => false;

        public virtual bool Multiply => false;

        /// <summary>
        /// The monster can cast nether balls.
        /// </summary>
        public virtual bool NetherBall => false;

        /// <summary>
        /// The monster can cast nether bolts.
        /// </summary>
        public virtual bool NetherBolt => false;

        public virtual bool NeverAttack => false;

        public virtual bool NeverMove => false;

        public virtual bool Nonliving => false;

        /// <summary>
        /// The distance at which the monster notices the player.
        /// </summary>
        public abstract int NoticeRange { get; }

        public virtual bool OnlyDropGold => false;

        public virtual bool OnlyDropItem => false;

        public virtual bool OpenDoor => false;

        public virtual bool Orc => false;

        public virtual bool PassWall => false;

        /// <summary>
        /// The monster can cast plasma bolts.
        /// </summary>
        public virtual bool PlasmaBolt => false;

        /// <summary>
        /// The monster can cast poison balls.
        /// </summary>
        public virtual bool PoisonBall => false;

        /// <summary>
        /// The monster can cast poison bolts.
        /// </summary>
        public virtual bool PoisonBolt => false;

        public virtual bool Powerful => false;

        /// <summary>
        /// The monster can cast nuke balls.
        /// </summary>
        public virtual bool RadiationBall => false;

        public virtual bool RandomMove25 => false;

        public virtual bool RandomMove50 => false;

        /// <summary>
        /// The rarity with which the monster is usually found.
        /// </summary>
        public abstract int Rarity { get; }

        public virtual bool Reflecting => false;

        public virtual bool Regenerate => false;

        public virtual bool ResistDisenchant => false;

        public virtual bool ResistNether => false;

        public virtual bool ResistNexus => false;

        public virtual bool ResistPlasma => false;

        public virtual bool ResistTeleport => false;

        public virtual bool ResistWater => false;

        public virtual bool Scare => false;

        public virtual bool Shapechanger => false;

        public virtual bool ShardBall => false;

        public virtual bool Shriek => false;

        /// <summary>
        /// How deeply the monster sleeps.
        /// </summary>
        public abstract int Sleep { get; }

        public virtual bool Slow => false;

        public virtual bool Smart => false;

        /// <summary>
        /// how fast the monster moves (110 = normal speed, higher is better).
        /// </summary>
        public abstract int Speed { get; }

        /// <summary>
        /// The shortened name of the monster.
        /// </summary>
        public abstract string SplitName1 { get; }

        /// <summary>
        /// The shortened name of the monster.
        /// </summary>
        public abstract string SplitName2 { get; }

        /// <summary>
        /// The shortened name of the monster.
        /// </summary>
        public abstract string SplitName3 { get; }

        public virtual bool Stupid => false;

        public virtual bool SummonAnt => false;

        public virtual bool SummonCthuloid => false;

        public virtual bool SummonDemon => false;

        public virtual bool SummonDragon => false;

        public virtual bool SummonGreatOldOne => false;

        public virtual bool SummonHiDragon => false;

        public virtual bool SummonHiUndead => false;

        public virtual bool SummonHound => false;

        public virtual bool SummonHydra => false;

        public virtual bool SummonKin => false;

        public virtual bool SummonMonster => false;

        public virtual bool SummonMonsters => false;

        public virtual bool SummonReaver => false;

        public virtual bool SummonSpider => false;

        public virtual bool SummonUndead => false;

        public virtual bool SummonUnique => false;

        public virtual bool TakeItem => false;

        public virtual bool TeleportAway => false;

        public virtual bool TeleportLevel => false;

        public virtual bool TeleportSelf => false;

        public virtual bool TeleportTo => false;

        public virtual bool Troll => false;

        public virtual bool Undead => false;

        public virtual bool Unique => false;

        /// <summary>
        /// The monster can cast water balls.
        /// </summary>
        public virtual bool WaterBall => false;

        /// <summary>
        /// The monster can cast water bolts.
        /// </summary>
        public virtual bool WaterBolt => false;

        public virtual bool WeirdMind => false;
    }
}