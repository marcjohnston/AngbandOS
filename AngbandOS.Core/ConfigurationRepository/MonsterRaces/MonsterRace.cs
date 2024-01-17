// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.MonsterRaces;

[Serializable]
internal abstract class MonsterRace : IMonsterCharacteristics
{
    protected readonly SaveGame SaveGame;
    protected MonsterRace(SaveGame saveGame)
    {
        SaveGame = saveGame;
        Knowledge = new MonsterKnowledge(saveGame, this);
        int freqInate = (FreqInate == 0 ? 0 : 100 / FreqInate);
        int freqSpell = (FreqSpell == 0 ? 0 : 100 / FreqSpell);
        FrequencyChance = (freqInate + freqSpell) / 2;

        Level = (LevelFound < 0 || LevelFound > 100) ? 0 : LevelFound;
    }
    public virtual MonsterSpellList Spells => new MonsterSpellList();
    public bool BreatheAcid => Spells.Contains(typeof(BreatheAcidMonsterSpell));
    public bool BreatheCold => Spells.Contains(typeof(BreatheColdMonsterSpell));
    public bool BreatheFire => Spells.Contains(typeof(BreatheFireMonsterSpell));
    public bool BreatheLightning => Spells.Contains(typeof(BreatheLightningMonsterSpell));
    public bool BreathePoison => Spells.Contains(typeof(BreathePoisonMonsterSpell));
    public bool BreatheChaos => Spells.Contains(typeof(BreatheChaosMonsterSpell));
    public bool BreatheConfusion => Spells.Contains(typeof(BreatheConfusionMonsterSpell));
    public bool BreatheDark => Spells.Contains(typeof(BreatheDarkMonsterSpell));
    public bool BreatheSound => Spells.Contains(typeof(BreatheSoundMonsterSpell));
    public bool BreatheForce => Spells.Contains(typeof(BreatheForceMonsterSpell));
    public bool BreatheShards => Spells.Contains(typeof(BreatheShardsMonsterSpell));
    public bool BreatheGravity => Spells.Contains(typeof(BreatheGravityMonsterSpell));
    public bool BreatheInertia => Spells.Contains(typeof(BreatheInertiaMonsterSpell));
    public bool BreatheTime => Spells.Contains(typeof(BreatheTimeMonsterSpell));
    public bool TeleportSelf => Spells.Contains(typeof(TeleportSelfMonsterSpell));

    public int CurNum;
    public bool Guardian;
    public bool OnlyGuardian;
    public int MaxNum;
    public MonsterKnowledge Knowledge;

    /// <summary>
    /// Returns a standard message note for a monster of either it 'dies' or is 'destroyed' based on whether
    /// or not the monster is already dead.  If it is already dead, a 'destroyed' message is returned and it 'dies'
    /// is returned for all living monsters.  Other variations are that dispel projectiles will dissolve and
    /// PSI will "collapses, a mindless husk".
    /// </summary>
    /// <param name="rPtr"></param>
    /// <returns></returns>
    public virtual string DeathNote()
    {
        if (Demon || Undead || Cthuloid || Stupid || Nonliving || "Evg".Contains(Symbol.Character.ToString()))
        {
            return " is destroyed.";
        }
        return " dies.";
    }

    /// <summary>
    /// Returns the symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }

    /// <summary>
    /// The color to display the monster as.
    /// </summary>
    public virtual ColourEnum Colour => ColourEnum.White;

    /// <summary>
    /// A unique identifier for the entity
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// The monster is an animal.
    /// </summary>
    public virtual bool Animal => false;

    /// <summary>
    /// The monsters armour class.
    /// </summary>
    public abstract int ArmourClass { get; }

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
    /// The monster is never seen, even with see invisible.
    /// </summary>
    public virtual bool CharClear => false;

    /// <summary>
    /// The monster is changes shape randomly.
    /// </summary>
    public virtual bool CharMulti => false;

    public virtual bool ColdBlood => false;

    public virtual bool Cthuloid => false;


    public virtual bool Demon => false;

    /// <summary>
    /// The descriptive text.
    /// </summary>
    public abstract string Description { get; }

    public virtual bool Dragon => false;

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

    /// The monster has maximum hit points.
    /// </summary>
    public virtual bool ForceMaxHp => false;

    /// <summary>
    /// The monster always starts asleep.
    /// </summary>
    public virtual bool ForceSleep => false;

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

    /// <summary>
    /// The number of hit dice the monster has.
    /// </summary>
    public abstract int Hdice { get; }

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

    /// <summary>
    /// The number of sides of the monster's hit dice.
    /// </summary>
    public abstract int Hside { get; }

    public virtual bool HurtByCold => false;

    public virtual bool HurtByFire => false;

    public virtual bool HurtByLight => false;

    public virtual bool HurtByRock => false;

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


    public virtual bool Male => false;

    /// <summary>
    /// The experience value for killing one of these.
    /// </summary>
    public abstract int Mexp { get; }

    public virtual bool MoveBody => false;

    public virtual bool Multiply => false;
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

    public virtual bool Powerful => false;

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

    public virtual bool Shapechanger => false;

    /// <summary>
    /// How deeply the monster sleeps.
    /// </summary>
    public abstract int Sleep { get; }

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

    public virtual bool TakeItem => false;

    public virtual bool Troll => false;

    public virtual bool Undead => false;

    public virtual bool Unique => false;

    public virtual bool WeirdMind => false;
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
    public int Index; // TODO: Needs to be removed.

    public int GetCoinType()
    {
        if (Symbol.Character == '$')
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