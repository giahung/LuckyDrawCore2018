using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckyDrawCore
{
    public static class DrawHelper
    {
        private static Random rand = new Random();
        private static List<string> nums = new List<string>();
        private static readonly string FILE_PATH_WINNERS = "Resources/Winners.txt";
        public static int CurrentStage = 11;


        private static readonly string DIRECTORY_PATH_WINNERS = "Resources";
        static DrawHelper()
        {
            LoadSource();
        }

        private static void LoadSource()
        {
            for (int i = 1; i <= 999; i++)
            {
                nums.Add(i.ToString("00#"));
            }
            var winners = LoadWinners();
            if (winners != null && winners.Any())
            {
                foreach (var item in winners)
                {
                    nums.Remove(item);
                }
            }
        }
        public static string GetWinner()
        {
            int index = rand.Next(nums.Count);
            string winner = nums[index];
            nums.RemoveAt(index);
            SaveWiner(winner);
            return winner;
        }

        private static void SaveWiner(string winner)
        {
            if (!Directory.Exists(DIRECTORY_PATH_WINNERS))
            {
                Directory.CreateDirectory(DIRECTORY_PATH_WINNERS);
            }

            using (StreamWriter sw = File.AppendText(FILE_PATH_WINNERS))
            {
                sw.WriteLine(string.Format("{0}", winner));
            }
        }

        private static List<string> LoadWinners()
        {
            if (File.Exists(FILE_PATH_WINNERS))
            {
                return File.ReadLines(FILE_PATH_WINNERS).ToList();
            }
            else
            {
                return null;
            }
        }

    }
}
