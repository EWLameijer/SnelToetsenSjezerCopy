using SnelToetsenSjezer.Domain.Models;

namespace SnelToetsenSjezer.Domain.Interfaces
{
    public interface IHotKeyService
    {
        void AddHotKey(string category, string description, string hotKeys);
        void ProcessHotkeysXmlFile(string filePath);
        List<string> GetCategories();
        List<HotKey> GetAllHotKeys();
        List<HotKey> GetHotKeysInCategory(string category);
        List<HotKey> GetHotKeysInCategories(List<string> categories);
    }
}
