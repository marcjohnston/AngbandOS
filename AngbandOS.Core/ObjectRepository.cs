using System.Reflection;

namespace AngbandOS.Core
{
    internal static class ObjectRepository
    {
        public static Dictionary<string, ProjectileGraphic> ProjectileGraphics = new Dictionary<string, ProjectileGraphic>();
        public static Dictionary<string, Animation> Animations = new Dictionary<string, Animation>();
        public static Dictionary<string, Vault> Vaults = new Dictionary<string, Vault>();
        public static Dictionary<string, FloorTileType> FloorTileTypes = new Dictionary<string, FloorTileType>();
        public static Dictionary<string, Base2RareItemType> RareItemTypes = new Dictionary<string, Base2RareItemType>();

        static ObjectRepository()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load ProjectileGraphics.
                if (!type.IsAbstract && typeof(ProjectileGraphic).IsAssignableFrom(type))
                {
                    ProjectileGraphic projectileGraphic = (ProjectileGraphic)Activator.CreateInstance(type);
                    ProjectileGraphics.Add(projectileGraphic.Name, projectileGraphic);
                }

                // Load Animations.
                if (!type.IsAbstract && typeof(Animation).IsAssignableFrom(type))
                {
                    Animation animation = (Animation)Activator.CreateInstance(type);
                    Animations.Add(animation.Name, animation);
                }

                // Load Vault Types.
                if (!type.IsAbstract && typeof(Vault).IsAssignableFrom(type))
                {
                    Vault vaultType = (Vault)Activator.CreateInstance(type);
                    Vaults.Add(vaultType.Name, vaultType);
                }

                // Load Floor Tile Type.
                if (!type.IsAbstract && typeof(FloorTileType).IsAssignableFrom(type))
                {
                    FloorTileType floorTileType = (FloorTileType)Activator.CreateInstance(type);
                    FloorTileTypes.Add(floorTileType.Name, floorTileType);
                }

                // Load Rare Item Type.
                if (!type.IsAbstract && typeof(Base2RareItemType).IsAssignableFrom(type))
                {
                    Base2RareItemType rareItemType = (Base2RareItemType)Activator.CreateInstance(type);
                    RareItemTypes.Add(rareItemType.Name, rareItemType);
                }
            }
        }
    }
}
