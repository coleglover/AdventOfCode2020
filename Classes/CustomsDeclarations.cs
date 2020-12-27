using System;
using System.Linq;
using System.Collections.Generic;


namespace AoC._2020
{
    class CustomsDeclaration
    {
        public static string[] ImportData()
        {
            string[] customsForms = System.IO.File.ReadAllText(@"C:\Users\Cole\source\repos\AoC.2020\InputData\Day06\Day06.Input.txt").
                                                Split(new string[] { "\r\n\r\n" },
                                                StringSplitOptions.RemoveEmptyEntries);
            return customsForms;
        }

        public static int CountDeclarations(string[] customsForms) 
        {
            int totalUniqueDeclarations = 0;
            int totalSharedDeclarations = 0;

            foreach(var groupEntry in customsForms) 
            {                             
                //< Part 1:
                var anyoneCount = groupEntry.Replace("\r\n", "").Distinct().Count();
                totalUniqueDeclarations += anyoneCount;

                //< converting group declaration forms from multiline to single line, then to string array
                //< "[space]" is used to differentiate between group and !group entries
                var declarations = groupEntry.Replace("\r\n", " ").ToCharArray().Select(value => value.ToString()).ToArray();
                var groupDict = new Dictionary<string, int>();
                int nMembers = 0;


                //< Part 2: 
                foreach (var claim in declarations)
                {
                    if (groupDict.ContainsKey(claim))
                        groupDict[claim]++;
                    else
                        groupDict[claim] = 1;
                }
         
                //< accounts for claims of groups with n = 1 members
                if (!groupDict.ContainsKey(" ")) 
                {
                    totalSharedDeclarations += groupDict.Count();
                }
                //< accounts for claims of groups with n > 1 members
                else if (groupDict[" "] > 0)
                {
                    //< storing n members in each group 
                    nMembers = groupDict[" "] + 1;
                    groupDict.Remove(" ");

                    groupDict = groupDict.Where(claim => claim.Value == nMembers)
                                                      .ToDictionary(claim => claim.Key, claim => claim.Value);

                    totalSharedDeclarations += groupDict.Count();
                }

                var orderedDict = groupDict.OrderBy(claim => claim.Value).ToDictionary(claim => claim.Key, claim => claim.Value);
            }

            Console.WriteLine($"\nTotal unique & shared customs declarations, respectively: {totalUniqueDeclarations} & {totalSharedDeclarations}");

            return totalUniqueDeclarations;
        }
    }
}
