using System;
namespace psuedoGAME
{
    class Job
    {
        private int _jobSelectIndex = 0;
        public string[] jobList = { "Swordsman", "Mage", "Thief", "Acolyte", "Archer", "Merchant" };
        public string GetJob()
        {
            foreach (var job in jobList)
            {
                Console.Write($"{job}");
            }
            return null;
        }
    }
}