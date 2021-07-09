using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTester
{
    class Program
    {
        private static Dictionary<string, int> InsertedStudyUID = new Dictionary<string, int>();


        static void Main(string[] args)
        {
            InsertedStudyUID.Add("1", 1);
            InsertedStudyUID.Add("2", 2);
            InsertedStudyUID.Add("3", 3);
            InsertedStudyUID.Add("4", 4);
            InsertedStudyUID.Add("5", 5);

            var currentInsertedStudyUID = new Dictionary<string, int>(InsertedStudyUID);

            foreach (KeyValuePair<string, int> insrtedStudyUID in currentInsertedStudyUID)
            {
                if (("3" == insrtedStudyUID.Key))
                {
                    InsertedStudyUID.Remove(insrtedStudyUID.Key);
                }
            }
        }
    }
}
