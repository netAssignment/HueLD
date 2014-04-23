using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManager.Models
{

    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Price { get; set; }
        public int CategoriesId { get; set; }
        public string Decription { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "{0} Không hợp lệ!")]
        public DateTime? DateUpdate { get; set; }
        public string PageNumber { get; set; }
        public string PictureName { get; set; }
        public int? NumberOfViews { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<TakePartIn> TakePartIns{ get; set; }
        public virtual Category Categories { get; set; }
        public virtual ICollection<BorrowerBooks> BorrowerBooks { get; set; }
    }
    public class Category
    {
        [Key]
        public int CategoriesId { get; set; }
        public string CategoriesName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class TakePartIn
    {

        //public int TakePartInId { get; set; }  
        [Key, Column(Order = 0)]
        public int AuthorId { get; set; }
        [Key, Column(Order = 1)]
        public int BookId { get; set; }
        [StringLength(50)]//Độ dài của TenTheLoai tối đa là 50
        public string Role { get; set; }
        public string Position { get; set; }     
        public virtual Book Book { get; set; }//Thuộc tính bên nhiều phải thuộc kiểu ICollection và tên của nó phải có hậu tố s
        public virtual Author Author { get; set; }
    }
    public class Author
    {
        public int AuthorId { get; set; }
        [StringLength(150)]
        public string AuthorName { get; set; }
        [StringLength(300)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public string Biography { get; set; }

        public ICollection<TakePartIn> TakePartIns { get; set; }//Thuộc tính kiểu thể loại
    }

    public class Borrower
    {
        [Key]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "{0} Không hợp lệ!")]
        public DateTime? DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public string Email { get; set; }

        public virtual ICollection<BorrowerBooks> BorrowerBooks { get; set; }
        public virtual Role Role { get; set; }
    }
   
    public class BorrowerBooks
    {
        [Key, Column(Order = 0)]
        public int BookId { get; set; }
        [Key, Column(Order = 1)]
        public string UserName { get; set; }
        [Key, Column(Order = 2)]
        public DateTime DateBorrow { get; set; }
        public DateTime? DateReturn { get; set; }

        public virtual Book Books { get; set; }
        public virtual Borrower Borrower { get; set; }
    }

    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<Borrower> Borrowers { get; set; }
    }
    public class BookContext : DbContext
    {
        public BookContext()
            : base("name=BookDBConnection")
        {
            System.Data.Entity.Database.SetInitializer(
                new System.Data.Entity.DropCreateDatabaseIfModelChanges<BookContext>());
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<TakePartIn> TakePartIns { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BorrowerBooks> BorrowerBooks { get; set; }
    }

    public class AddDataToDatabase
    {
        BookContext db = new BookContext();
        public AddDataToDatabase()
        {
            AddAuthor();
            AddCategory();
            AddRole();
            AddBorower();
            AddBook();
            AddTakePartIn();
            AddBorrowerBooks();
        }
        public void AddAuthor()
        {
            var author1 = new Author()
            {
                AuthorId = 1,
                AuthorName = "Julia Donaldson",
                Address = "San francisco",
                PhoneNumber = "213456789",
                Biography = ""
            };
            var author2 = new Author()
            {
                AuthorId = 2,
                AuthorName = "Beth Carswell",
                Address = "Los Angles",
                PhoneNumber = "98765432",
                Biography = "dsfsf"
            };
            db.Authors.Add(author1);
            db.Authors.Add(author2);
            db.SaveChanges();
        }
        public void AddCategory()
        {
            var category1 = new Category() { CategoriesName = "All" };
            var category2 = new Category() { CategoriesName = "Children books" };
            var category3 = new Category() { CategoriesName = "Business books books" };
            var category4 = new Category() { CategoriesName = "Literature books" };
            var category5 = new Category() { CategoriesName = "Music books" };
            var category6 = new Category() { CategoriesName = "Technology books" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.Categories.Add(category4);
            db.Categories.Add(category5);
            db.Categories.Add(category6);
            db.SaveChanges();
        }
        public void AddRole()
        {
            var role1 = new Role() { RoleName = "Super Admin" };
            var role2 = new Role() { RoleName = "Admin" };
            var role3 = new Role() { RoleName = "Borrower" };
            db.Roles.Add(role1);
            db.Roles.Add(role2);
            db.Roles.Add(role3);
            db.SaveChanges();
        }
        public void AddBorower()
        {
            var b1 = new Borrower()
            {
                UserName = "Hue",
                Password = "123",
                Address = "abc",
                PhoneNumber = "12345",
                RoleId = 1,
                DateOfBirth = new DateTime(1992, 4, 23),
                IsMale = true,
                Email = "duchuecntt@gmail.com"
            };
            var b2 = new Borrower()
            {
                UserName = "Chinh",
                Password = "123",
                Address = "def",
                PhoneNumber = "54321",
                RoleId = 2,
                DateOfBirth = new DateTime(1991, 3, 30),
                IsMale = false,
                Email = "chinh@gmail.com"
            };
            var b3 = new Borrower()
            {
                UserName = "Joshua",
                Password = "123",
                Address = "mno",
                PhoneNumber = "98765",
                RoleId = 3,
                DateOfBirth = new DateTime(1990, 11, 30),
                IsMale = true,
                Email = "Joshua@gmail.com"
            };
            db.Borrowers.Add(b1);
            db.Borrowers.Add(b2);
            db.Borrowers.Add(b3);
            db.SaveChanges();
        }
        public void AddBook()
        {
            var book1 = new Book()
            {
                BookName = "The Gruffalo in Scots",
                Price = "50",
                CategoriesId = 2,
                Decription = @"We don't think there's anyone, anywhere in the book-loving world who hasn't heard of the Gruffalo.
                Julia Donaldson's lovable and unforgettable creation has enchanted little ones for over a decade and now young Scottish
                readers can enjoy this very special edition of Julia's tale starring the much-adored Gruffalo, now told in flowing Scots!
                The original story's illustrations by Axel Scheffler help make this the perfect keepsake for any proud Scot!",
                DateUpdate = new DateTime(2014, 3, 26),
                PageNumber = "60",
                PictureName = "GRUS_childrenBook.jpg",
                NumberOfViews = 0,
                IsDelete = false
            };
            var book2 = new Book()
            {
                BookName = "Old Macdonald Had a Zoo",
                Price = "10",
                CategoriesId = 2,
                Decription = @"After winning the lottery, Old MacDonald decides to sell up his farm
                and buy a zoo with his winnings - but what will the old farm animals make of this? 
                With liftable flaps adding extra interaction to this brilliant twist on a well-known tale,
                the book hilariously reveals how the zoo animals picked off the farm animals one by one.
                From the talented mind of Curtis Jobling and the amazing illustrator Tom McLaughlin,
                this is a laugh-out-loud book for child and parent.",
                DateUpdate = new DateTime(2014, 3, 26),
                PageNumber = "20",
                PictureName = "OLM2.jpg",
                NumberOfViews = 1,
                IsDelete = false
            };
            var book3 = new Book()
            {
                BookName = "Books Signed by Musicians",
                Price = "120",
                CategoriesId = 5,
                Decription = @"Music is the soundtrack to our memories and one of life’s
                great pleasures. And the people who write, sing and play live a rollercoaster existence in the glare of the public eye.
                These stars suffer heartbreak and heartache, personal tragedies,
                drug and alcohol addiction, in-fighting and real fighting,
                financial woes despite earning a fortune, and the odd loneliness of life on the road.
                These books are fascinating reads and signed too.",
                DateUpdate = new DateTime(2010, 3, 26),
                PageNumber = "256",
                PictureName = "greendale-neil-young.jpg",
                NumberOfViews = 1,
                IsDelete = false
            };
            db.Books.Add(book1);
            db.Books.Add(book2);
            db.Books.Add(book3);
            db.SaveChanges();
        }
        public void AddTakePartIn()
        {
            var t1 = new TakePartIn()
            {
                AuthorId = 1,
                BookId = 1,
                Role = "Writer",
                Position = "Main"
            };
            var t2 = new TakePartIn()
            {
                AuthorId = 1,
                BookId = 2,
                Role = "Writer",
                Position = "Main"
            };
            var t3 = new TakePartIn()
            {
                AuthorId = 2,
                BookId = 3,
                Role = "Writer",
                Position = "Main"
            };
            db.TakePartIns.Add(t1);
            db.TakePartIns.Add(t2);
            db.TakePartIns.Add(t3);
            db.SaveChanges();
        }
        public void AddBorrowerBooks()
        {
            var b1 = new BorrowerBooks()
            {
                BookId = 1,
                UserName = "Hue",
                DateBorrow=new DateTime(2014,4,2),
                DateReturn = new DateTime(2014, 4, 3)
            };

            var b2 = new BorrowerBooks()
            {
                BookId = 1,
                UserName = "Chinh",
                DateBorrow = new DateTime(2014, 4, 12),
            };
            db.BorrowerBooks.Add(b1);
            db.BorrowerBooks.Add(b2);
            db.SaveChanges();
        }
    }
}