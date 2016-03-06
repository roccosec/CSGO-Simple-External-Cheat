﻿namespace Smurf.GlobalOffensive.Patchables
{
    internal class Offsets
    {
        public class Misc
        {
            public static int EntityList = 0x04A98174;
            public static int ViewMatrix = 0x04A4E584;
            public static int LocalPlayer = 0x00A7D4CC;
            public static int Jump = 0x04F2CE08;
        }

        public class ClientState
        {
            //ClientState
            public static int Base = 0x006082C4;
            public static int LocalPlayerIndex = 0x00000178;
            //Ingame
            public static int GameState = 0x100;
            public static int ViewAngles = 0x00004D0C;
        }

        public class BaseEntity
        {
            //m_vecOrigin
            public static int Position = 0x134;
            public static int Team = 0xF0;
            public static int Armor = 0x0000A8E4;
            public static int Health = 0xFC;
            public static int Dormant = 0x000000E9;
            public static int Index = 0x64;
            public static int EntitySize = 0x10;
            public static int Spotted = 0x00000939;
            public static int BoneMatrix = 0x00002698;
            public static int SpottedByMask = 0x0000097C;
        }

        public class Player
        {
            public static int LifeState = 0x0000025B;
            public static int Flags = 0x100;
            public static int ActiveWeapon = 0x00002EE8; // m_hActiveWeapon
            public static int VecVelocity = 0x00000110;
            public static int GunGameImmune = 0x000038A0;
            public static int FlashMaxAlpha = 0x0000A2E4;
        }

        public class LocalPlayer
        {
            public static int CrosshairId = 0xA950;
            public static int VecViewOffset = 0x00000104;
            public static int VecPunch = 0x00003018;
            public static int ShotsFired = 0xA2B0;
        }

        public class Weapon
        {
            public static int ItemDefinitionIndex = 0x000032B4;
            public static int State = 0x000031E8;
            public static int Clip1 = 0x000031F4;
            // public static int NextPrimaryAttack = 0x000031C8;
            public static int WeaponId = 0x000032DC;
            //public static int CanReload = 0x00003235;
            public static int WeaponTableIndex = 0x00004E70;
            public static int AccuracyPenalty = 0x00004EC0;
            public static int ZoomLevel = 0x00003330;
        }
    }
}