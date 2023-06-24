using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShaTask.Data;
using ShaTask.Interfaces;
using ShaTask.Models;
using ShaTask.ViewModels;

namespace ShaTask.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ShaTaskContext _context;
        private readonly IInvoiceHeaderRepository _invoiceHeaderRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository, ShaTaskContext context, IInvoiceHeaderRepository invoiceHeaderRepository)
        {
            _invoiceRepository = invoiceRepository;
            _context = context;
            _invoiceHeaderRepository = invoiceHeaderRepository;
        }
        public async Task<IActionResult> Index()
        {
            // Ta
            // ShaTaskContext db = new ShaTaskContext();


            IEnumerable<Item> items = await _invoiceRepository.GetAll();

            //me
            //List<Item> items = _context.Items.ToList();

            //TA
            // var items =  db.Items.Include(a => a.Id);
            return View(items/*.ToList()*/);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemViewModel ItemVM)
        {
            if (ModelState.IsValid) 
            {
                var item = new Item
                {
                    ItemName = ItemVM.ItemName,
                    ItemPrice = ItemVM.ItemPrice,

                };

                _invoiceRepository.Add(item);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Faild creating");
            }

            return View(ItemVM);
        }


        public async Task<IActionResult> Edit(long id)
        {
            var item  = await _invoiceRepository.GetByIdAsync(id);
            if (item == null)
                return View("Error");

            var itemVM = new EditItemViewModel
            {
                ItemName = item.ItemName,
                ItemPrice = item.ItemPrice,
            };

            return View(itemVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(long id, EditItemViewModel itemVM)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Faild editing item");
                return View("Edit", itemVM);
            }
            var useritem = await _invoiceRepository.GetByIdAsync(id);

            if (useritem != null)
            {
                var item = new Item
                {
                    Id = id,
                    ItemName = itemVM.ItemName,
                    ItemPrice = itemVM.ItemPrice,
                };

                _invoiceRepository.Update(item);

                return RedirectToAction("Index");
            }
            else
            {
                return View(itemVM);
            }

        }

        public async Task<IActionResult> Delete (long id)
        {
            var itemDetails = await _invoiceRepository.GetByIdAsync(id);

            if (itemDetails == null)
                return View("Error");

            return View(itemDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var itemDetails =  await _invoiceRepository.GetByIdAsync(id);

            if (itemDetails == null)
                return View("Error");

            _invoiceRepository.Delete(itemDetails);
            return RedirectToAction("Index");

        }

        public IActionResult Header()
        {

            return View();
        }

        [HttpPost, ActionName("Header")]
        public async Task<IActionResult> InvoiceHeader( /*List<int> itemIds, List<decimal> totalPrices*/)
        {
                
                if (ModelState.IsValid)
                {
                    var invoiceHeader = new InvoiceHeader
                    {
                        
                            CustomerName = "hasan she7ata",
                            CashierId = 2,
                            BranchId = 2,
                            InvoiceTotal = 150.0,

                    };

                  


                 _invoiceHeaderRepository.Add(invoiceHeader);
                 return RedirectToAction("index");




                }
              
                return View();
        }
        

    }
}
