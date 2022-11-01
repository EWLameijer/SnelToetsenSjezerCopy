using SnelToetsenSjezer.Domain.Enums;
using SnelToetsenSjezer.Domain.Interfaces;
using SnelToetsenSjezer.Domain.Models;
using SnelToetsenSjezer.Domain.Types;
using System.Xml;

namespace SnelToetsenSjezer.Business
{
    public class HotKeyService : IHotKeyService
    {
        private readonly List<HotKey> _allHotKeys = new() { };

        public HotKeySolutions SolutionsStringToObject(string solutions)
        {
            HotKeySolutions allSolutions = new HotKeySolutions();
            bool multipleSolutions = solutions.Contains("||");
            List<string> solutionsStrings = multipleSolutions ? solutions.Split("||").ToList() : new List<string>() { solutions };

            solutionsStrings.ToList().ForEach(solutionString =>
            {
                HotKeySolution newSolution = new HotKeySolution();
                List<string> solutionStrSteps = solutionString.Split(",").ToList();

                solutionStrSteps.ToList().ForEach(solutionStrStep =>
                {
                    HotKeySolutionStep newSolutionStep = new HotKeySolutionStep();
                    bool isString = solutionStrStep.Contains("'");
                    bool isCombination = solutionStrStep.Contains("+");

                    if (isString)
                    {
                        newSolutionStep.Add(new SolutionStepPart()
                        {
                            Type = SolutionStepPartType.String,
                            Value = solutionStrStep.Substring(1, solutionStrStep.Length - 2)
                        });
                    }
                    else if (isCombination)
                    {
                        solutionStrStep.Split("+").ToList().ForEach(solutionStrStepPart =>
                        {
                            newSolutionStep.Add(new SolutionStepPart()
                            {
                                Type = SolutionStepPartType.Key,
                                Value = solutionStrStepPart
                            });
                        });
                    }
                    else
                    {
                        newSolutionStep.Add(new SolutionStepPart()
                        {
                            Type = SolutionStepPartType.Key,
                            Value = solutionStrStep
                        });
                    }

                    newSolution.Add(newSolutionStep);
                });

                allSolutions.Add(newSolution);
            });

            return allSolutions;
        }

        public void AddHotKey(string category, string description, string solutions)
        {
            HotKey myNewHotKey = new HotKey()
            {
                Category = category,
                Description = description,
                Solutions = SolutionsStringToObject(solutions)
            };
            _allHotKeys.Add(myNewHotKey);
        }

        public void ProcessHotkeysXmlFile(string filePath)
        {
            XmlDocument hotKeysXml = new XmlDocument();
            hotKeysXml.Load(filePath);

            if (hotKeysXml.DocumentElement != null)
            {
                foreach (XmlNode node in hotKeysXml.DocumentElement.ChildNodes)
                {
                    string? category = node.Attributes?["name"]?.InnerText;
                    if (!string.IsNullOrEmpty(category))
                    {
                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            string? description = childNode.Attributes?["description"]?.InnerText;
                            string? keys = childNode.Attributes?["keys"]?.InnerText;

                            if (!string.IsNullOrEmpty(description) && !string.IsNullOrEmpty(keys))
                            {
                                AddHotKey(category, description, keys);
                            }
                        }
                    }
                }
            }
        }
        public List<string> GetCategories()
        {
            List<string> Categories = new List<string>();
            _allHotKeys.GroupBy(hk => hk.Category).ToList().ForEach(hk_item =>
            {
                Categories.Add(hk_item.ElementAt(0).Category);
            });
            return Categories;
        }

        public List<HotKey> GetAllHotKeys()
        {
            return _allHotKeys;
        }
        public List<HotKey> GetHotKeysInCategory(string category)
        {
            if (category.Length < 1) return new List<HotKey> { };
            return _allHotKeys.Where(hk => hk.Category == category).ToList();
        }
        public List<HotKey> GetHotKeysInCategories(List<string> categories)
        {
            if (categories.Count() < 1) return new List<HotKey> { };
            return _allHotKeys.Where(hk => categories.Contains(hk.Category)).ToList();
        }
    }
}