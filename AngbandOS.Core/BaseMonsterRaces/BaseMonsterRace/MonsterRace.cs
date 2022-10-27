using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.StaticData
{
    [Serializable]
    internal abstract class MonsterRace
    {
        public int CurNum;
        public uint Flags1;
        public int MaxNum;
        public MonsterKnowledge Knowledge;

        public readonly uint Flags2;
        public readonly uint Flags3;

        /// <summary>
        /// Represents innate abilities.  Monsters that do not have innate abilities cannot use these flags.
        /// </summary>
        public readonly uint Flags4;
        public readonly uint Flags5;
        public readonly uint Flags6;

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
        /// Returns all of the attacks that the monster can perform in a single round.
        /// </summary>
        public virtual MonsterAttack[]? Attacks => null;

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
        public abstract int LevelFound { get; }

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

        /// <summary>
        /// Returns true, if the monster is smart.  When badly injured, the monster will want to prioritise spells that disable the
        /// player, summon help, or let it escape over spells that do direct damage.
        /// </summary>
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

        public MonsterRace()
        {
            int freqInate = (FreqInate == 0 ? 0 : 100 / FreqInate);
            int freqSpell = (FreqSpell == 0 ? 0 : 100 / FreqSpell);
            FrequencyChance = (freqInate + freqSpell) / 2;

            Level = (LevelFound < 0 || LevelFound > 100) ? 0 : LevelFound;

            Flags1 |= AttrClear ? MonsterFlag1.AttrClear : 0;
            Flags1 |= AttrMulti ? MonsterFlag1.AttrMulti : 0;
            Flags1 |= CharClear ? MonsterFlag1.CharClear : 0;
            Flags1 |= CharMulti ? MonsterFlag1.CharMulti : 0;
            Flags1 |= Drop_1D2 ? MonsterFlag1.Drop_1D2 : 0;
            Flags1 |= Drop_2D2 ? MonsterFlag1.Drop_2D2 : 0;
            Flags1 |= Drop_3D2 ? MonsterFlag1.Drop_3D2 : 0;
            Flags1 |= Drop_4D2 ? MonsterFlag1.Drop_4D2 : 0;
            Flags1 |= Drop60 ? MonsterFlag1.Drop60 : 0;
            Flags1 |= Drop90 ? MonsterFlag1.Drop90 : 0;
            Flags1 |= DropGood ? MonsterFlag1.DropGood : 0;
            Flags1 |= DropGreat ? MonsterFlag1.DropGreat : 0;
            Flags1 |= Escorted ? MonsterFlag1.Escorted : 0;
            Flags1 |= EscortsGroup ? MonsterFlag1.EscortsGroup : 0;
            Flags1 |= Female ? MonsterFlag1.Female : 0;
            Flags1 |= ForceMaxHp ? MonsterFlag1.ForceMaxHp : 0;
            Flags1 |= ForceSleep ? MonsterFlag1.ForceSleep : 0;
            Flags1 |= Friends ? MonsterFlag1.Friends : 0;
            Flags1 |= Male ? MonsterFlag1.Male : 0;
            Flags1 |= NeverAttack ? MonsterFlag1.NeverAttack : 0;
            Flags1 |= NeverMove ? MonsterFlag1.NeverMove : 0;
            Flags1 |= OnlyDropGold ? MonsterFlag1.OnlyDropGold : 0;
            Flags1 |= OnlyDropItem ? MonsterFlag1.OnlyDropItem : 0;
            Flags1 |= RandomMove25 ? MonsterFlag1.RandomMove25 : 0;
            Flags1 |= RandomMove50 ? MonsterFlag1.RandomMove50 : 0;
            Flags1 |= Unique ? MonsterFlag1.Unique : 0;
            Flags2 |= AttrAny ? MonsterFlag2.AttrAny : 0;
            Flags2 |= LightningAura ? MonsterFlag2.LightningAura : 0;
            Flags2 |= FireAura ? MonsterFlag2.FireAura : 0;
            Flags2 |= BashDoor ? MonsterFlag2.BashDoor : 0;
            Flags2 |= ColdBlood ? MonsterFlag2.ColdBlood : 0;
            Flags2 |= ColdBlood ? MonsterFlag2.ColdBlood : 0;
            Flags2 |= EmptyMind ? MonsterFlag2.EmptyMind : 0;
            Flags2 |= Invisible ? MonsterFlag2.Invisible : 0;
            Flags2 |= KillBody ? MonsterFlag2.KillBody : 0;
            Flags2 |= KillItem ? MonsterFlag2.KillItem : 0;
            Flags2 |= KillWall ? MonsterFlag2.KillWall : 0;
            Flags2 |= MoveBody ? MonsterFlag2.MoveBody : 0;
            Flags2 |= Multiply ? MonsterFlag2.Multiply : 0;
            Flags2 |= OpenDoor ? MonsterFlag2.OpenDoor : 0;
            Flags2 |= PassWall ? MonsterFlag2.PassWall : 0;
            Flags2 |= Powerful ? MonsterFlag2.Powerful : 0;
            Flags2 |= Reflecting ? MonsterFlag2.Reflecting : 0;
            Flags2 |= Regenerate ? MonsterFlag2.Regenerate : 0;
            Flags2 |= Shapechanger ? MonsterFlag2.Shapechanger : 0;
            Flags2 |= Smart ? MonsterFlag2.Smart : 0;
            Flags2 |= Stupid ? MonsterFlag2.Stupid : 0;
            Flags2 |= TakeItem ? MonsterFlag2.TakeItem : 0;
            Flags2 |= WeirdMind ? MonsterFlag2.WeirdMind : 0;
            Flags3 |= Animal ? MonsterFlag3.Animal : 0;
            Flags3 |= Cthuloid ? MonsterFlag3.Cthuloid : 0;
            Flags3 |= Demon ? MonsterFlag3.Demon : 0;
            Flags3 |= Dragon ? MonsterFlag3.Dragon : 0;
            Flags3 |= Evil ? MonsterFlag3.Evil : 0;
            Flags3 |= Giant ? MonsterFlag3.Giant : 0;
            Flags3 |= Good ? MonsterFlag3.Good : 0;
            Flags3 |= GreatOldOne ? MonsterFlag3.GreatOldOne : 0;
            Flags3 |= HurtByCold ? MonsterFlag3.HurtByCold : 0;
            Flags3 |= HurtByFire ? MonsterFlag3.HurtByFire : 0;
            Flags3 |= HurtByLight ? MonsterFlag3.HurtByLight : 0;
            Flags3 |= HurtByRock ? MonsterFlag3.HurtByRock : 0;
            Flags3 |= ImmuneAcid ? MonsterFlag3.ImmuneAcid : 0;
            Flags3 |= ImmuneCold ? MonsterFlag3.ImmuneCold : 0;
            Flags3 |= ImmuneLightning ? MonsterFlag3.ImmuneLightning : 0;
            Flags3 |= ImmuneFire ? MonsterFlag3.ImmuneFire : 0;
            Flags3 |= ImmunePoison ? MonsterFlag3.ImmunePoison : 0;
            Flags3 |= ImmuneConfusion ? MonsterFlag3.ImmuneConfusion : 0;
            Flags3 |= ImmuneFear ? MonsterFlag3.ImmuneFear : 0;
            Flags3 |= Nonliving ? MonsterFlag3.Nonliving : 0;
            Flags3 |= ImmuneSleep ? MonsterFlag3.ImmuneSleep : 0;
            Flags3 |= ImmuneStun ? MonsterFlag3.ImmuneStun : 0;
            Flags3 |= Orc ? MonsterFlag3.Orc : 0;
            Flags3 |= ResistDisenchant ? MonsterFlag3.ResistDisenchant : 0;
            Flags3 |= ResistNether ? MonsterFlag3.ResistNether : 0;
            Flags3 |= ResistNexus ? MonsterFlag3.ResistNexus : 0;
            Flags3 |= ResistPlasma ? MonsterFlag3.ResistPlasma : 0;
            Flags3 |= ResistTeleport ? MonsterFlag3.ResistTeleport : 0;
            Flags3 |= ResistWater ? MonsterFlag3.ResistWater : 0;
            Flags3 |= Troll ? MonsterFlag3.Troll : 0;
            Flags3 |= Undead ? MonsterFlag3.Undead : 0;
            Flags4 |= Arrow1D6 ? MonsterFlag4.Arrow1D6 : 0;
            Flags4 |= Arrow3D6 ? MonsterFlag4.Arrow3D6 : 0;
            Flags4 |= Arrow5D6 ? MonsterFlag4.Arrow5D6 : 0;
            Flags4 |= Arrow7D6 ? MonsterFlag4.Arrow7D6 : 0;
            Flags4 |= ChaosBall ? MonsterFlag4.ChaosBall : 0;
            Flags4 |= RadiationBall ? MonsterFlag4.RadiationBall : 0;
            Flags4 |= BreatheAcid ? MonsterFlag4.BreatheAcid : 0;
            Flags4 |= BreatheChaos ? MonsterFlag4.BreatheChaos : 0;
            Flags4 |= BreatheCold ? MonsterFlag4.BreatheCold : 0;
            Flags4 |= BreatheConfusion ? MonsterFlag4.BreatheConfusion : 0;
            Flags4 |= BreatheDark ? MonsterFlag4.BreatheDark : 0;
            Flags4 |= BreatheDisenchant ? MonsterFlag4.BreatheDisenchant : 0;
            Flags4 |= BreatheDisintegration ? MonsterFlag4.BreatheDisintegration : 0;
            Flags4 |= BreatheLightning ? MonsterFlag4.BreatheLightning : 0;
            Flags4 |= BreatheFire ? MonsterFlag4.BreatheFire : 0;
            Flags4 |= BreatheGravity ? MonsterFlag4.BreatheGravity : 0;
            Flags4 |= BreatheInertia ? MonsterFlag4.BreatheInertia : 0;
            Flags4 |= BreatheLight ? MonsterFlag4.BreatheLight : 0;
            Flags4 |= BreatheMana ? MonsterFlag4.BreatheMana : 0;
            Flags4 |= BreatheNether ? MonsterFlag4.BreatheNether : 0;
            Flags4 |= BreatheNexus ? MonsterFlag4.BreatheNexus : 0;
            Flags4 |= BreatheRadiation ? MonsterFlag4.BreatheRadiation : 0;
            Flags4 |= BreathePlasma ? MonsterFlag4.BreathePlasma : 0;
            Flags4 |= BreathePoison ? MonsterFlag4.BreathePoison : 0;
            Flags4 |= BreatheShards ? MonsterFlag4.BreatheShards : 0;
            Flags4 |= BreatheSound ? MonsterFlag4.BreatheSound : 0;
            Flags4 |= BreatheTime ? MonsterFlag4.BreatheTime : 0;
            Flags4 |= BreatheForce ? MonsterFlag4.BreatheForce : 0;
            Flags4 |= ShardBall ? MonsterFlag4.ShardBall : 0;
            Flags4 |= Shriek ? MonsterFlag4.Shriek : 0;
            Flags5 |= AcidBall ? MonsterFlag5.AcidBall : 0;
            Flags5 |= ColdBall ? MonsterFlag5.ColdBall : 0;
            Flags5 |= DarkBall ? MonsterFlag5.DarkBall : 0;
            Flags5 |= LightningBall ? MonsterFlag5.LightningBall : 0;
            Flags5 |= FireBall ? MonsterFlag5.FireBall : 0;
            Flags5 |= ManaBall ? MonsterFlag5.ManaBall : 0;
            Flags5 |= NetherBall ? MonsterFlag5.NetherBall : 0;
            Flags5 |= PoisonBall ? MonsterFlag5.PoisonBall : 0;
            Flags5 |= WaterBall ? MonsterFlag5.WaterBall : 0;
            Flags5 |= Blindness ? MonsterFlag5.Blindness : 0;
            Flags5 |= AcidBolt ? MonsterFlag5.AcidBolt : 0;
            Flags5 |= ColdBolt ? MonsterFlag5.ColdBolt : 0;
            Flags5 |= LightningBolt ? MonsterFlag5.LightningBolt : 0;
            Flags5 |= FireBolt ? MonsterFlag5.FireBolt : 0;
            Flags5 |= IceBolt ? MonsterFlag5.IceBolt : 0;
            Flags5 |= ManaBolt ? MonsterFlag5.ManaBolt : 0;
            Flags5 |= NetherBolt ? MonsterFlag5.NetherBolt : 0;
            Flags5 |= PlasmaBolt ? MonsterFlag5.PlasmaBolt : 0;
            Flags5 |= PoisonBolt ? MonsterFlag5.PoisonBolt : 0;
            Flags5 |= WaterBolt ? MonsterFlag5.WaterBolt : 0;
            Flags5 |= BrainSmash ? MonsterFlag5.BrainSmash : 0;
            Flags5 |= CauseLightWounds ? MonsterFlag5.CauseLightWounds : 0;
            Flags5 |= CauseSeriousWounds ? MonsterFlag5.CauseSeriousWounds : 0;
            Flags5 |= CauseCriticalWounds ? MonsterFlag5.CauseCriticalWounds : 0;
            Flags5 |= CauseMortalWounds ? MonsterFlag5.CauseMortalWounds : 0;
            Flags5 |= Confuse ? MonsterFlag5.Confuse : 0;
            Flags5 |= DrainMana ? MonsterFlag5.DrainMana : 0;
            Flags5 |= Hold ? MonsterFlag5.Hold : 0;
            Flags5 |= MindBlast ? MonsterFlag5.MindBlast : 0;
            Flags5 |= MagicMissile ? MonsterFlag5.MagicMissile : 0;
            Flags5 |= Scare ? MonsterFlag5.Scare : 0;
            Flags5 |= Slow ? MonsterFlag5.Slow : 0;
            Flags6 |= Blink ? MonsterFlag6.Blink : 0;
            Flags6 |= Darkness ? MonsterFlag6.Darkness : 0;
            Flags6 |= DreadCurse ? MonsterFlag6.DreadCurse : 0;
            Flags6 |= Forget ? MonsterFlag6.Forget : 0;
            Flags6 |= Haste ? MonsterFlag6.Haste : 0;
            Flags6 |= Heal ? MonsterFlag6.Heal : 0;
            Flags6 |= SummonAnt ? MonsterFlag6.SummonAnt : 0;
            Flags6 |= SummonCthuloid ? MonsterFlag6.SummonCthuloid : 0;
            Flags6 |= SummonDemon ? MonsterFlag6.SummonDemon : 0;
            Flags6 |= SummonDragon ? MonsterFlag6.SummonDragon : 0;
            Flags6 |= SummonGreatOldOne ? MonsterFlag6.SummonGreatOldOne : 0;
            Flags6 |= SummonHiDragon ? MonsterFlag6.SummonHiDragon : 0;
            Flags6 |= SummonHiUndead ? MonsterFlag6.SummonHiUndead : 0;
            Flags6 |= SummonHound ? MonsterFlag6.SummonHound : 0;
            Flags6 |= SummonHydra ? MonsterFlag6.SummonHydra : 0;
            Flags6 |= SummonKin ? MonsterFlag6.SummonKin : 0;
            Flags6 |= SummonMonster ? MonsterFlag6.SummonMonster : 0;
            Flags6 |= SummonMonsters ? MonsterFlag6.SummonMonsters : 0;
            Flags6 |= SummonReaver ? MonsterFlag6.SummonReaver : 0;
            Flags6 |= SummonSpider ? MonsterFlag6.SummonSpider : 0;
            Flags6 |= SummonUndead ? MonsterFlag6.SummonUndead : 0;
            Flags6 |= SummonUnique ? MonsterFlag6.SummonUnique : 0;
            Flags6 |= TeleportAway ? MonsterFlag6.TeleportAway : 0;
            Flags6 |= TeleportLevel ? MonsterFlag6.TeleportLevel : 0;
            Flags6 |= TeleportTo ? MonsterFlag6.TeleportTo : 0;
            Flags6 |= TeleportSelf ? MonsterFlag6.TeleportSelf : 0;
            Flags6 |= CreateTraps ? MonsterFlag6.CreateTraps : 0;
        }

        /// <summary>
        /// Represents a percentage chance (0-100) of successfully casting as spell.
        /// </summary>
        public int FrequencyChance { get; }

        /// <summary>
        /// Returns the level at which the monster will appear.  This is typically same as LevelFound but Player and the NobodyGhost are moved to the town level.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Returns the index into the monster race array where the monster is.  Set just after construction.
        /// </summary>
        public int Index;

        public int GetCoinType()
        {
            if (Character == '$')
            {
                if (Name.Contains(" copper "))
                {
                    return 2;
                }
                if (Name.Contains(" silver "))
                {
                    return 5;
                }
                if (Name.Contains(" gold "))
                {
                    return 10;
                }
                if (Name.Contains(" mithril "))
                {
                    return 16;
                }
                if (Name.Contains(" adamantite "))
                {
                    return 17;
                }
                if (Name.StartsWith("Copper "))
                {
                    return 2;
                }
                if (Name.StartsWith("Silver "))
                {
                    return 5;
                }
                if (Name.StartsWith("Gold "))
                {
                    return 10;
                }
                if (Name.StartsWith("Mithril "))
                {
                    return 16;
                }
                if (Name.StartsWith("Adamantite "))
                {
                    return 17;
                }
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{Name} (lvl {Level})";
        }
    }
}