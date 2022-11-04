// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Enumerations
{
    /// <summary>
    /// Represents 31 flags.
    /// </summary>
    internal static class ItemFlag3
    {
        public const uint Activate = 0x01000000;
        public const uint Aggravate = 0x08000000;
        public const uint AntiTheft = 0x00000008;
        public const uint Blessed = 0x10000000;
        public const uint Cursed = 0x20000000;
        public const uint DrainExp = 0x02000000;
        public const uint DreadCurse = 0x00000080;
        public const uint EasyKnow = 0x00000100;
        public const uint Feather = 0x00001000;
        public const uint HeavyCurse = 0x40000000;
        public const uint HideType = 0x00000200;
        public const uint IgnoreAcid = 0x00100000;
        public const uint IgnoreCold = 0x00800000;
        public const uint IgnoreElec = 0x00200000;
        public const uint IgnoreFire = 0x00400000;

        /// <summary>
        /// Bitwise value to represent whether the item is an instant artifact.  Artifacts cannot be made worthless, nor can they be created by Wizards?
        /// </summary>
        public const uint InstaArt = 0x00000800;

        public const uint Lightsource = 0x00002000;
        public const uint NoMagic = 0x00000020;
        public const uint NoTele = 0x00000010;
        public const uint PermaCurse = 0x80000000;
        public const uint Regen = 0x00020000;
        public const uint SeeInvis = 0x00004000;
        public const uint ShElec = 0x00000002;
        public const uint ShFire = 0x00000001;
        public const uint ShowMods = 0x00000400; // Show ToHit and ToDamage modifiers.  This is applied to all 61 weapons and the ring of slaying.
        public const uint SlowDigest = 0x00010000;
        public const uint Telepathy = 0x00008000;
        public const uint Teleport = 0x04000000;
        public const uint Wraith = 0x00000040;
        public const uint XtraMight = 0x00040000;
        public const uint XtraShots = 0x00080000;

        /// <summary>
        /// Unused flag ... currently flag based cost is 0.
        /// </summary>
        public const uint Xxx3 = 0x00000004;
    }
}