﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using IniParser;
using IniParser.Model;

namespace Smurf.GlobalOffensive
{
    public class Settings
    {
        private static readonly FileIniDataParser Parser = new FileIniDataParser();
        private IniData _data;
        private WinAPI.VirtualKeyShort _reloadConfigKey;

        public Settings()
        {
            if (!File.Exists("Config.ini"))
            {
                CreateConfigFile();
            }
            _data = Parser.ReadFile("Config.ini");
        }


        public void Update()
        {
            _reloadConfigKey = (WinAPI.VirtualKeyShort) Convert.ToInt32(Smurf.Settings.GetString("Misc", "Reload Config Key"), 16);
            if (Smurf.KeyUtils.KeyWentDown(_reloadConfigKey)) //Tab Key, don't hard code key, will fix later.
            {
                Console.WriteLine("Reload Config.");
                _data = Parser.ReadFile("Config.ini");
            }
        }
        private void CreateConfigFile()
        {
            List<string> snipersList = new List<string>
            {
                "AWP",
                "SSG08",
                "SCAR20",
                "G3SG1",

            };
            List<string> machineGunList = new List<string>
            {
                "M249",
                "Negev",
            };

            List<string> heavyList = new List<string>
            {
                "NOVA",
                "XM1014",
                "Sawedoff",
                "Mag7",
            };

            List<string> smgList = new List<string>
            {
                "MAC10",
                "MP9",
                "MP7",
                "UMP45",
                "Bizon",
                "P90",
            };

            List<string> pistolList = new List<string>
            {
                "DEagle",
                "Elite",
                "FiveSeven",
                "Glock",
                "P228",
                "P250",
                "HKP2000",
                "Tec9",
            };

            List<string> rifleList = new List<string>
            {
                "GalilAR",
                "AK47",
                "SG556",
                "Famas",
                "M4A1",
                "Aug",
            };

            var builder = new StringBuilder();
            builder.AppendLine("[Bunny Jump]");
            builder.AppendLine("Bunny Jump Enabled = True");
            builder.AppendLine("Bunny Jump Key = 0x20").AppendLine();

            //SoundESP
            builder.AppendLine("[Sound ESP]");
            builder.AppendLine("Sound ESP = True");
            builder.AppendLine("Sound Range = 10");
            builder.AppendLine("Sound Interval = 1000");
            builder.AppendLine("Sound Track = 1");
            builder.AppendLine("Sound Volume = 100").AppendLine();
            //Misc
            builder.AppendLine("[Misc]");
            builder.AppendLine("Radar = True");
            builder.AppendLine("Auto Pistol = False");
            builder.AppendLine("Auto Pistol Delay = 0");
            builder.AppendLine("No Flash = False");
            builder.AppendLine("Reload Config Key = 0x35").AppendLine();

            foreach (var weapon in pistolList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }
            foreach (var weapon in rifleList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }
            foreach (var weapon in smgList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }
            foreach (var weapon in snipersList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = False");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }
            foreach (var weapon in machineGunList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }
            foreach (var weapon in heavyList)
            {
                builder.AppendLine("[" + weapon + "]");
                //RCS
                builder.AppendLine("Rcs Enabled = True");
                builder.AppendLine("Rcs Start = 1");
                builder.AppendLine("Rcs Force Yaw = 2");
                builder.AppendLine("Rcs Force Pitch = 2").AppendLine();
                //Trigger
                builder.AppendLine("Trigger Enabled = True");
                builder.AppendLine("Trigger Key = 0x12");
                builder.AppendLine("Trigger Enemies = True");
                builder.AppendLine("Trigger Allies = False");
                builder.AppendLine("Trigger Burst Enabled = False");
                builder.AppendLine("Trigger Spawn Protected = False");
                builder.AppendLine("Trigger Delay FirstShot = 35");
                builder.AppendLine("Trigger Delay Shots = 35").AppendLine();
            }


            if (!File.Exists("Config.ini"))
            {
                var sr = new StreamWriter(@"Config.ini");
                sr.WriteLine(builder);
                sr.Close();
            }
        }

        public int GetInt(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = int.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public string GetString(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = keyValue;
                return setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "M4A1";
        }

        public uint GetUInt(string section, string key)
        {
            var keyValue = _data[section][key];
            var setting = uint.Parse(keyValue);
            return setting;
        }

        public float GetFloat(string section, string key)
        {
            try
            {
                string keyValue = _data[section][key];
                float setting = float.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return 0;
        }

        public bool GetBool(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var setting = bool.Parse(keyValue);
                return setting;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }

        public WinAPI.VirtualKeyShort GetKey(string section, string key)
        {
            try
            {
                var keyValue = _data[section][key];
                var button = (WinAPI.VirtualKeyShort)int.Parse(keyValue);
                return button;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return WinAPI.VirtualKeyShort.ACCEPT;
        }
    }
}
