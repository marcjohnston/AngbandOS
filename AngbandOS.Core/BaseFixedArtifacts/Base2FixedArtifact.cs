// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Debug;
using AngbandOS.Enumerations;
using AngbandOS.Core.Interface;
using AngbandOS.ItemCategories;

namespace AngbandOS.Core
{
    [Serializable]
    internal abstract class Base2FixedArtifact
    {
        public abstract BaseItemCategory BaseItemCategory { get; }

        public abstract char Character { get; }
        public virtual Colour Colour => Colour.White;
        public abstract string Name { get; }

        public abstract int Ac { get; }

        public virtual bool Activate => false;

        public virtual bool Aggravate => false;

        public virtual bool Blessed => false;

        public virtual bool Blows => false;

        public virtual bool BrandAcid => false;

        public virtual bool BrandCold => false;

        public virtual bool BrandElec => false;

        public virtual bool BrandFire => false;

        public virtual bool BrandPois => false;

        public virtual bool Cha => false;

        public virtual bool Chaotic => false;

        public virtual bool Con => false;

        public abstract int Cost { get; }

        public virtual bool Cursed => false;

        public abstract int Dd { get; }

        public virtual bool Dex => false;

        public virtual bool DrainExp => false;

        public virtual bool DreadCurse => false;

        public abstract int Ds { get; }

        public virtual bool EasyKnow => false;

        public virtual bool Feather => false;

        public abstract FixedArtifactId FixedArtifactID { get; }

        public virtual bool FreeAct => false;

        public abstract string FriendlyName { get; }

        public virtual bool HasOwnType => false;

        public virtual bool HeavyCurse => false;

        public virtual bool HideType => false;

        public virtual bool HoldLife => false;

        public virtual bool IgnoreAcid => false;

        public virtual bool IgnoreCold => false;

        public virtual bool IgnoreElec => false;

        public virtual bool IgnoreFire => false;

        public virtual bool ImAcid => false;

        public virtual bool ImCold => false;

        public virtual bool ImElec => false;

        public virtual bool ImFire => false;

        public virtual bool Impact => false;

        public virtual bool Infra => false;

        public virtual bool InstaArt => false;

        public virtual bool Int => false;

        public virtual bool KillDragon => false;

        public abstract int Level { get; }

        public virtual bool Lightsource => false;

        public virtual bool NoMagic => false;

        public virtual bool NoTele => false;

        public virtual bool PermaCurse => false;

        public abstract int Pval { get; }

        public abstract int Rarity { get; }

        public virtual bool Reflect => false;

        public virtual bool Regen => false;

        public virtual bool ResAcid => false;

        public virtual bool ResBlind => false;

        public virtual bool ResChaos => false;

        public virtual bool ResCold => false;

        public virtual bool ResConf => false;

        public virtual bool ResDark => false;

        public virtual bool ResDisen => false;

        public virtual bool ResElec => false;

        public virtual bool ResFear => false;

        public virtual bool ResFire => false;

        public virtual bool ResLight => false;

        public virtual bool ResNether => false;

        public virtual bool ResNexus => false;

        public virtual bool ResPois => false;

        public virtual bool ResShards => false;

        public virtual bool ResSound => false;

        public virtual bool Search => false;

        public virtual bool SeeInvis => false;

        public virtual bool ShElec => false;

        public virtual bool ShFire => false;

        public virtual bool ShowMods => false;

        public virtual bool SlayAnimal => false;

        public virtual bool SlayDemon => false;

        public virtual bool SlayDragon => false;

        public virtual bool SlayEvil => false;

        public virtual bool SlayGiant => false;

        public virtual bool SlayOrc => false;

        public virtual bool SlayTroll => false;

        public virtual bool SlayUndead => false;

        public virtual bool SlowDigest => false;

        public virtual bool Speed => false;

        public virtual bool Stealth => false;

        public virtual bool Str => false;

        public virtual bool SustCha => false;

        public virtual bool SustCon => false;

        public virtual bool SustDex => false;

        public virtual bool SustInt => false;

        public virtual bool SustStr => false;

        public virtual bool SustWis => false;

        public virtual bool Telepathy => false;

        public virtual bool Teleport => false;

        public abstract int ToA { get; }

        public abstract int ToD { get; }

        public abstract int ToH { get; }

        public virtual bool Tunnel => false;

        public virtual bool Vampiric => false;

        public virtual bool Vorpal => false;

        public abstract int Weight { get; }

        public virtual bool Wis => false;

        public virtual bool Wraith => false;

        public virtual bool XtraMight => false;

        public virtual bool XtraShots => false;
    }
}
