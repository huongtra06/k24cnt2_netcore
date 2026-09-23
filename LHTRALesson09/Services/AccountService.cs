using System.Text.Json;
using LHTRALesson09.Models;

namespace LHTRALesson09.Services;

public class AccountService
{
    private readonly string _filePath;

    public AccountService(IWebHostEnvironment env)
    {
        var dataFolder = Path.Combine(env.ContentRootPath, "Data");
        Directory.CreateDirectory(dataFolder);
        _filePath = Path.Combine(dataFolder, "accounts.json");

        if (!File.Exists(_filePath))
        {
            Save(new List<Account>
            {
                new()
                {
                    Id = 1,
                    FullName = "Nguyễn Văn An",
                    Email = "nguyenvanan@gmail.com",
                    Phone = "0901234567",
                    Address = "Hà Nội",
                    BirthDate = new DateTime(2000, 5, 12),
                    Gender = "Nam",
                    FacebookUrl = "https://facebook.com/",
                    Avatar = null
                },
                new()
                {
                    Id = 2,
                    FullName = "Trần Thị Mai",
                    Email = "tranthimai@gmail.com",
                    Phone = "0912345678",
                    Address = "Hải Phòng",
                    BirthDate = new DateTime(2001, 8, 20),
                    Gender = "Nữ",
                    FacebookUrl = "https://facebook.com/",
                    Avatar = null
                }
            });
        }
    }

    public List<Account> GetAll()
    {
        if (!File.Exists(_filePath)) return new List<Account>();
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Account>>(json) ?? new List<Account>();
    }

    public Account? GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public void Add(Account account)
    {
        var list = GetAll();
        account.Id = list.Count == 0 ? 1 : list.Max(x => x.Id) + 1;
        account.CreatedAt = DateTime.Now;
        list.Add(account);
        Save(list);
    }

    public bool Update(Account account)
    {
        var list = GetAll();
        var old = list.FirstOrDefault(x => x.Id == account.Id);
        if (old == null) return false;

        account.CreatedAt = old.CreatedAt;
        account.Password ??= old.Password;
        account.Avatar ??= old.Avatar;

        var index = list.FindIndex(x => x.Id == account.Id);
        list[index] = account;
        Save(list);
        return true;
    }

    public bool Delete(int id)
    {
        var list = GetAll();
        var item = list.FirstOrDefault(x => x.Id == id);
        if (item == null) return false;

        list.Remove(item);
        Save(list);
        return true;
    }

    private void Save(List<Account> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(_filePath, JsonSerializer.Serialize(accounts, options));
    }
}
