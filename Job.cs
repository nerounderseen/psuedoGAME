using System.Collections.Generic;

namespace psuedoGAME
{
    public class Job
    {
        public int id;
        public string name;
        public string identifier;
        public string descript;
        private static List<Job> _firstJobList = new List<Job>()
        {
            new Job {id = 01, identifier= "swordsman", name = "Swordsman", descript ="Apprentice of the sword"},
            new Job {id = 02, identifier= "thief", name = "Thief", descript ="Apprentice of the dark"},
            new Job {id = 03, identifier= "mage", name = "Mage", descript ="Apprentice of the mystic"},
            new Job {id = 04, identifier= "archer", name = "Archer", descript ="Apprentice of the hunt"},
            new Job {id = 05, identifier= "merchant", name = "Merchant", descript ="Apprentice of the craft"},
            new Job {id = 06, identifier= "acolyte", name ="Acolyte", descript ="Apprentice of the light"}
        };

        public Job InputItem(string identifier)
        {
            foreach (Job job in _firstJobList)
            {
                if (job.identifier == identifier)
                {
                    return job;
                }
            }
            return null;
        }

        public List<Job> ShowFirstJobList()
        {
            List<Job> jobListCopy = new List<Job>();
            jobListCopy = _firstJobList;
            return jobListCopy;
        }
    }
}