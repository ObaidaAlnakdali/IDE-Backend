using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IDE_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IDEContext _context;
        public ItemController(IDEContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpGet("ItemsByUserId")]
        public async Task<ActionResult<List<Item>>> GetItemsByUserId(int UserId)
        {
            var items = await _context.Items.
                Where(x => x.UserId == UserId).
                Include(i => i.User).
                Include(i => i.Status).
                ToListAsync();
            return items;
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> Create(ItemDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
                return NotFound();

            var status = await _context.Statuses.FindAsync(request.StatusId);
            if (status == null)
                return NotFound();

            var newItem = new Item
            {
                Title = request.Title,
                Category = request.Category,
                DueDate = request.DueDate,
                Estimate = request.Estimate,
                Importance = request.Importance,
                Status = status,
                User = user
            };

            _context.Items.Add(newItem);
            await _context.SaveChangesAsync();
            return await GetItemsByUserId(newItem.UserId);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ItemDto item)
        {
            // Use of lambda expression to access
            // particular record from a database
            var data = _context.Items.FirstOrDefault(x => x.Id == id);
            // Checking if any such record exist
            if (data != null)
            {
                data.Title = item.Title;
                data.Category = item.Category;
                data.DueDate = item.DueDate;
                data.Estimate = item.Estimate;
                data.Importance = item.Importance;
                data.StatusId = item.StatusId;
                data.UserId = item.UserId;
                _context.SaveChanges();

                return Ok("Success!");
            }
            else
                return Ok("The card not found");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
           try
            {
            if (_context.Items == null)
                    return NotFound();

                var item = await _context.Items.FindAsync(id);
                if (item == null)
                    return NotFound();

                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("Deleted is success");
           } catch
            {
                return BadRequest();
           }
        }
    }
}
