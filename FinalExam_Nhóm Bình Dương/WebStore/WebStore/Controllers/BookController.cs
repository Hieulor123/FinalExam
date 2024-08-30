using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WedStore.Repositories;

namespace WedStore.Controllers
{

    
    public class BookController : Controller
    {
        // GET: BookController
        public ActionResult Index(int page)
        {
            // Kiểm Tra Trang
            if (page < 1)
            {
                page = 1;
            }

            // Lấy Danh Sách Tất Cả Sách từ lớp BookRes
            var lstBook = BookRes.GetAll();

            // Lấy Danh Sách Loại Sách từ lớp BookTypeRes
            var lstBookType = BookTypeRes.GetAllType();

            // Kiểm Tra Để Chắc Chắn lstBookType Không Phải Null
            if (lstBookType == null)
            {
                lstBookType = new List<BookType>(); // Khởi Tạo Danh Sách Nếu Nó Là Null
            }

            // Tạo Danh Sách Sách Hiển Thị Trong Trang
            List<Book> books = new List<Book>();
            int bookPerPage = 6;
            for (int i = (page - 1) * bookPerPage; i < page * bookPerPage; i++)
            {
                if (lstBook.Count == i)
                {
                    break;
                }
                books.Add(lstBook[i]);
            }

            // Tính Số Trang Tối Đa
            int MaxPage = lstBook.Count / bookPerPage;
            int tmp = lstBook.Count % bookPerPage; // Số Dư
            if (tmp >= 1) MaxPage += 1;

            // Tạo Đối Tượng Dynamic để Truyền Dữ Liệu vào View
            dynamic dy = new ExpandoObject();
            dy.book = books;
            dy.booktypeNAV = lstBookType;
            dy.maxpage = MaxPage;
            dy.currentpage = page;

            return View(dy);
        }

        public ActionResult BookType(string ID, int page)
        {
            // Kiểm Tra Trang
            if (page < 1)
            {
                page = 1;
            }

            // Lấy Danh Sách Loại Sách
            var lstBookTypeList = BookTypeRes.GetAllType();

            // Lấy Danh Sách Sách Theo Loại
            var lstBook = BookRes.GetTypeList(ID);

            // Tạo Danh Sách Sách Hiển Thị Trong Trang
            List<Book> books = new List<Book>();
            int bookPerPage = 6;
            for (int i = (page - 1) * bookPerPage; i < page * bookPerPage; i++)
            {
                if (lstBook.Count == i)
                {
                    break;
                }
                books.Add(lstBook[i]);
            }

            // Lấy Loại Sách Theo ID
            var BookType = BookTypeRes.BookTypeWithID(ID);

            // Tính Số Trang Tối Đa
            int MaxPage = lstBook.Count / bookPerPage;
            int tmp = lstBook.Count % bookPerPage; // Số Dư
            if (tmp >= 1) MaxPage += 1;

            // Tạo Đối Tượng Dynamic Để Truyền Dữ Liệu vào View
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = lstBookTypeList; // Sửa lỗi ở đây, biến `lstBookTypeList` đã được khai báo
            dy.booktypelist = books;
            dy.booktype = BookType;
            dy.maxpage = MaxPage;
            dy.currentpage = page;

            return View(dy);
        }

        // GET: BookController/Details/id
        public ActionResult Details(string id)
        {
            // Fetch the book with the specified ID
            var book = BookRes.BookWithID(id);

            // Initialize the dynamic object to pass data to the view
            dynamic dy = new ExpandoObject();
            dy.booktypeNAV = BookTypeRes.GetAllType(); // Get all book types
            dy.bookdetail = book; // Use the already fetched book to avoid fetching again

            // Fetch all books for further operations
            var lstBookWithType = BookRes.GetAll();

            if (book == null)
            {
                // Handle the case where no book is found
                return NotFound(); // Return 404 error or a custom view
            }

            // Filter out the book details from the list
            var it = lstBookWithType.SingleOrDefault(r => r.BookID == book.BookID);

            if (it != null)
            {
                lstBookWithType.Remove(it); // Remove it if found
            }

            // Ensure the list is not empty after removing the item
            List<Book> lstBook = new List<Book>();

            if (lstBookWithType.Count >= 3)
            {
                // Randomly select 3 books from the remaining list
                Random rnd = new Random();
                for (int i = 1; i <= 3; i++)
                {
                    int random = rnd.Next(lstBookWithType.Count);
                    int j = 0;
                    foreach (var item in lstBookWithType)
                    {
                        if (j == random)
                        {
                            lstBook.Add(item);
                            lstBookWithType.Remove(item);
                            break;
                        }
                        j++;
                    }
                }
            }
            else
            {
                // If fewer than 3 books remain, add all of them
                lstBook.AddRange(lstBookWithType);
            }

            dy.lstBook = lstBook; // Set the list of books for display

            return View(dy); // Return the view with the dynamic object
        }
    }
}
