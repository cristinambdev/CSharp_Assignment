using Business.Models;

namespace Business.Interfaces
{
    public interface IFileService
    {
        List<Contact> LoadListFromFile();
        void SaveListToFile(List<Contact> list);
    }
}