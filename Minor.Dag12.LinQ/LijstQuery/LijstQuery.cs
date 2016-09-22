using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag12.LinqOefening
{
    public class LijstQuery
    {

        public static List<string> _lijst = new List<string>
        {
            "Yael", "Rouke", "Wesley", "Simon", "Martin", "Jelle",
            "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
            "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
            "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery",
        };

        #region comprehensionsyntax
        public List<char> getFirstLettersThatContainR()
        {
            return getFirstLettersThatContainR(_lijst);
        }


        public List<char> getFirstLettersThatContainR(List<string> lijst)
        {
            var firstLettersQuery = from persoon in lijst
                                    where persoon.Contains('R') || persoon.Contains('r')
                                    select persoon[0];
            return firstLettersQuery.ToList();
        }

        public List<int> GetLengthOfNamesStartingWithJ()
        {
            return GetLengthOfNamesStartingWithJ(_lijst);
        }

        public List<int> GetLengthOfNamesStartingWithJ(List<string> lijst)
        {
            var StartWithJQuery = from persoon in lijst
                                  where persoon[0] == 'J'
                                  orderby persoon.Length descending
                                  select persoon.Length;
            return StartWithJQuery.ToList();
        }

        public List<int> GetListOfNumberOfNamesGroupedByNameLength()
        {
            return GetListOfNumberOfNamesGroupedByNameLength(_lijst);
        }

        public List<int> GetListOfNumberOfNamesGroupedByNameLength(List<string> lijst)
        {
            var GroupNamesByNameLengthQuery = from persoonNaam in lijst
                                              group persoonNaam by persoonNaam.Length into NaamLengteGroep
                                              orderby NaamLengteGroep.Key ascending
                                              select NaamLengteGroep.Count();
        
            return GroupNamesByNameLengthQuery.ToList();
        }

        public List<string> GetListOfShortestNamesThatDontContainA()
        {
            return GetListOfShortestNamesThatDontContainA(_lijst);
        }

        public List<string> GetListOfShortestNamesThatDontContainA(List<string> lijst)
        {
            var GroupNamesByNameLengthQuery = from persoonNaam in lijst
                                              group persoonNaam by persoonNaam.Length into NaamLengteGroep
                                              orderby NaamLengteGroep.Key ascending
                                              select NaamLengteGroep;

            var FindNamesThatDontContainAQuery = from naam in GroupNamesByNameLengthQuery.First()
                                                 where !naam.Contains("a") && !naam.Contains("A")
                                                 select naam;

            return FindNamesThatDontContainAQuery.ToList();
        }

        #endregion

        public List<char> ExtensionFindAllFirstLettersInNamesThatContainR()
        {
            return ExtensionFindAllFirstLettersInNamesThatContainR(_lijst);
        }

        public List<char> ExtensionFindAllFirstLettersInNamesThatContainR(List<string> lijst)
        {
            return lijst.Where(name => name.ToLower().Contains('r')).Select(persoon => persoon[0]).ToList();
        }

        public List<int> ExtensionFindLengthOfNamesThatStartWithJ()
        {
            return ExtensionFindLengthOfNamesThatStartWithJ(_lijst);
        }

        public List<int> ExtensionFindLengthOfNamesThatStartWithJ(List<string> list)
        {
            return list.Where(persoonNaam => persoonNaam[0] == 'J').OrderByDescending(persoonNaam => persoonNaam.Length).Select(persoonNaam => persoonNaam.Length).ToList();
        }

        public List<int> GroupNameByLengthAndReturnCount()
        {
            return GroupNameByLengthAndReturnCount(_lijst);
        }
        public List<int> GroupNameByLengthAndReturnCount(List<string> list)
        {
            return list.GroupBy(personNaam => personNaam.Length, personNaam => personNaam.Length).OrderBy(groepen => groepen.Key).Select(groep => groep.Count()).ToList();
        }

        public List<string> GroupNameAndReturnListOfShortestNames(List<string> list)
        {
            return list.GroupBy(naam => naam.Length).OrderBy(groep => groep.Key).First().Where(naam => !naam.ToLower().Contains('a')).ToList();
        }
    }
}
