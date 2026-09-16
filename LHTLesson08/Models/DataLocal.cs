namespace LHTLesson08.Models
{
    public static class DataLocal
    {
        public static List<People> People = new List<People>
        {
            new People
            {
                Id = 1,
                Name = "Luong Huong Tra",
                Email = "lht@gmail.com",
                Phone = "0123456789",
                Address = "Hà Nội",
                Avatar = "avatar/images/anh1.jpg",
                Birthday = new DateTime(2000, 1, 1),
                Bio = "Sinh viên",
                Gender = "2"
            },
            new People
            {
                Id = 2,
                Name = "Trần Thị Bình",
                Email = "binh@gmail.com",
                Phone = "0987654321",
                Address = "Hải Phòng",
                Avatar = "avatar/images/anh2.jpg",
                Birthday = new DateTime(2001, 5, 10),
                Bio = "Sinh viên",
                Gender = "2"
            },
            new People
            {
                Id = 3,
                Name = "Nguyễn Văn An",
                Email = "an@gmail.com",
                Phone = "0912345678",
                Address = "Đà Nẵng",
                Avatar = "avatar/image/anh3.jpg",
                Birthday = new DateTime(1999, 8, 15),
                Bio = "Sinh viên",
                Gender = "1"
            },
            new People
            {
                Id = 4,
                Name = "Phạm Minh Anh",
                Email = "anh@gmail.com",
                Phone = "0901234567",
                Address = "Hồ Chí Minh",
                Avatar = "avatar/images/anh4.jpg",
                Birthday = new DateTime(2002, 3, 20),
                Bio = "Sinh viên",
                Gender = "2"
            },
            new People
            {
                Id = 5,
                Name = "Lê Quốc Huy",
                Email = "huy@gmail.com",
                Phone = "0934567890",
                Address = "Hà Nội",
                Avatar = "avatar/images/anh5.jpg",
                Birthday = new DateTime(2000, 11, 25),
                Bio = "Sinh viên",
                Gender = "1"
            }
        };
    }
}