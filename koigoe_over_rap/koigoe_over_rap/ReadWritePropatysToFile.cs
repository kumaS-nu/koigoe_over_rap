using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace koigoe_over_rap
{
    /// <summary>
    /// このプログラムで使うプロパティのセーブ・ロードをまとめたクラス
    /// </summary>
    static class ReadWritePropatysToFile
    {
        public static uint[] ReadEQ()
        {
            uint[] eq_set = new uint[4];
            if (!File.Exists("eq_set.ini"))
            {
                File.WriteAllText("eq_set.ini", "0\n0\n0\n0\n");
            }
            IEnumerable<string> r_temps = File.ReadLines("eq_set.ini");
            for (int i = 0; i < 4; i++)
            {
                if (!uint.TryParse(r_temps.Skip(i).First(), out eq_set[i]))
                {
                    eq_set[i] = 0;
                }
                else if (eq_set[i] > 4)
                {
                    eq_set[i] = 0;
                }
            }

            return eq_set;
        }
        public static void WriteEQ(uint[] EQset)
        {
            string[] temp = { EQset[0].ToString(), EQset[1].ToString(), EQset[2].ToString(), EQset[3].ToString() };
            File.WriteAllLines("eq_set.ini", temp);
        }

        public static string[] ReadPath()
        {
            if (!File.Exists("path.ini"))
            {
                File.Create("path.ini").Close();
            }
            return File.ReadAllLines("path.ini").Take(2).ToArray();
        }

        public static void WritePath(string[] path)
        {
            File.WriteAllLines("path.ini", path);
        }

        public static uint ReadOutputDevNum()
        {
            if (!File.Exists("output_dev_num.ini"))
            {
                File.WriteAllText("output_dev_num.ini", "0");
            }
            uint.TryParse(File.ReadAllText("output_dev_num.ini"), out uint outputDevNum);

            return outputDevNum;
        }

        public static void WriteOutputDevNum(uint dev)
        {
            File.WriteAllText("output_dev_num.ini", dev.ToString());
        }

        public static TimeSpan ReadResetInterval()
        {
            if (!File.Exists("reset_interval.ini"))
            {
                File.WriteAllText("reset_interval.ini", 20.ToString());
            }
            string r_temp = File.ReadAllText("reset_interval.ini");
            int.TryParse(r_temp, out int ri_temp);

            return new TimeSpan(0, ri_temp, 0);

        }

        public static void WriteResetInterval(int minute)
        {
            if (minute >= 0)
            {
                File.WriteAllText("reset_interval.ini", minute.ToString());
            }
        }

        public static string ReadOutputDevice()
        {
            if (!File.Exists("OutputDevice.ini"))
            {
                File.Create("OutputDevice.ini").Close();
            }

            return File.ReadAllText("OutputDevice.ini");
        }

        public static void WriteOutputDevice(string device)
        {
            File.WriteAllText("OutputDevice.ini", device);
        }

        public static Keys[] ReadShortcatKeys()
        {
            if (!File.Exists("Shortcat_keys.ini"))
            {
                File.WriteAllText("Shortcat_keys.ini", "P\nL\nO\nK");
            }
            string[] temp = File.ReadAllLines("Shortcat_keys.ini");
            Keys[] keys = new Keys[4];
            for(int i = 0; i < 4; i++)
            {
                keys[i] = (Keys)Enum.Parse(typeof(Keys),temp[i],true);
            }

            return keys;
        } 

        public static void WriteShortcatKeys(Keys[] keys)
        {
            string[] write = { keys[0].ToString(), keys[1].ToString(), keys[2].ToString(), keys[3].ToString() };
            File.WriteAllLines("Shortcat_keys.ini", write);
        }

        public static List<string> ReadGameProcess()
        {
            if (!File.Exists("GameProcess.ini"))
            {
                File.WriteAllText("GameProcess.ini", "");
            }
            return File.ReadAllLines("GameProcess.ini").ToList();
        }

        public static void WriteGameProcess(string[] gameProcess)
        {
            File.WriteAllLines("GameProcess.ini", gameProcess);
        }
    }
}
