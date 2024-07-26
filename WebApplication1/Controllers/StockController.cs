using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StockController : Controller
    {

        readonly ApplicationDbContext _context;

        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var stocks = _context.Stocks.ToList();
            return View(stocks);
        }

        [Route("Stock/Detay/{stock_id}")]
        public IActionResult Detay(int stock_id)

        {
            var stock = _context.Stocks.Find(stock_id);
            if (stock == null)
            {
                return NotFound();
            }

            stock.Comments = _context.Comments.Where(c => c.StockId == stock_id).ToList();
            return View(stock);
        }
        [HttpPost]
        public IActionResult AddComment(int StockId, string Content, string Title)
        {
            Comment add = new Comment()
            {
                StockId = StockId,
                Content = Content,
                Title = Title,
                DateTime = DateTime.Now
            };

            _context.Comments.Add(add);
            _context.SaveChanges();

            return RedirectToAction("Detay", new { stock_id = StockId });
        }

        public IActionResult DeleteComment(int id) {
            Comment comment = _context.Comments.Find(id);
            int stock_id =  Convert.ToInt32(comment.StockId);
            if (comment == null)
            {
                return NotFound();
            }
          
                

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("Detay", new { stock_id = comment.StockId });
        }
    }
}

