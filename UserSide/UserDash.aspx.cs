using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace LibraryManagement.UserSide
{
    public partial class UserDash : System.Web.UI.Page
    {
        private readonly BookService _bookService;

        public UserDash()
        {
            _bookService = new BookService();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await FetchAllBooks();
            }
        }

        private async Task FetchAllBooks()
        {
            List<Book> books = await _bookService.FetchAllBooks();
            booksRepeater.DataSource = books;
            booksRepeater.DataBind();
        }

        protected async void fetchButton_Click(object sender, EventArgs e)
        {
            await FetchBooks();

        }

        private async Task FetchBooks()
        {
            string query = queryInput.Text.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                List<Book> books = await _bookService.FetchBooksByQuery(query);
                booksRepeater.DataSource = books;
                booksRepeater.DataBind();
            }
        }
    }
}