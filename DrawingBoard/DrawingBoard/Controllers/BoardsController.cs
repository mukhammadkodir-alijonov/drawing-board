using Microsoft.AspNetCore.Mvc;

namespace DrawingBoard.Controllers
{
    public class BoardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            // Retrieve the board with the given id from the database and return it to the view
            return View();
        }

        // POST: Boards/Create
        [HttpPost]
        public ActionResult Create(Board board)
        {
            // Add the new board to the database
            return View(board);
        }

        // POST: Boards/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Board board)
        {
            // Update the board in the database
            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            // Delete the board from the database
            return View();
        }
    }
}
