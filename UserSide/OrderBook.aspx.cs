using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace LibraryManagement.UserSide
{
    public partial class OrderBook : System.Web.UI.Page
    {
        private readonly BookService _bookService;

        public OrderBook()
        {
            _bookService = new BookService();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            
                await FetchBooks();
        }

        private async Task FetchBooks()
        {
            string title = Request.QueryString["otitle"].ToString();

            string query = title.Trim();
            if (!string.IsNullOrEmpty(query))
            {
                List<Book> books = await _bookService.FetchBooksByQuery(query);
                orderlistshow.DataSource = books;
                orderlistshow.DataBind();
            }
        }
    }
}