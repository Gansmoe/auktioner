using auktioner.Models;
using auktioner.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace auktioner.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {

        private readonly IProductRepository _productsRepository;
        private readonly ICategoryRepository _categoriesRepository;

        private AppDbContext _appDbContext;

        public ProductController(AppDbContext appDbContext, IProductRepository productRepository, ICategoryRepository categoriesRepository)
        {
            _appDbContext = appDbContext;
            _productsRepository = productRepository;
            _categoriesRepository = categoriesRepository;
        }


        public IActionResult Products()
        {

            ProductListViewModel productListViewModel = new ProductListViewModel();
            productListViewModel.Products = _productsRepository.AllProducts;

            return View(productListViewModel);
        }

        public IActionResult AddProduct()
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductViewModel.categories = _categoriesRepository.AllCategories;
            return View(addProductViewModel);
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
            var product = new Products();
            product.Name = addProductViewModel.Name;
            product.ProductId = addProductViewModel.ProductId;
            product.Description = addProductViewModel.Description;
            product.BuyPrice = addProductViewModel.BuyPrice;
            product.StartPrice = addProductViewModel.StartPrice;
            product.Year = addProductViewModel.Year;
            product.Category = addProductViewModel.Category;
            addProductViewModel.categories = _categoriesRepository.AllCategories;

            var newproducts = _productsRepository.AllProducts.ToList();

            if (ModelState.IsValid)
            {

                if (newproducts.Count == 0)
                {
                    product.Id = 1;
                    _appDbContext.Products.Add(product);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("AddProductComplete");

                }
                else
                {
                    var newId = _appDbContext.Products.Select(x => x.Id).Max() + 1;
                    product.Id = newId;
                    _appDbContext.Products.Add(product);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("AddProductComplete");
                }

            }
            else
            {
                return View(addProductViewModel);
            }
        }

        public IActionResult AddProductComplete()
        {
            ViewBag.AddProductCompleteMessage = "Artikeln tillagd!";
            return View();
        }

        public IActionResult Edit(int id)
        {
            AddProductViewModel addProductViewModel = new AddProductViewModel();
            addProductViewModel.categories = _categoriesRepository.AllCategories;

            var product = _appDbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            addProductViewModel.ProductId = product.ProductId;
            addProductViewModel.Name = product.Name;
            addProductViewModel.Description = product.Description;
            addProductViewModel.Year = product.Year;
            addProductViewModel.StartPrice = product.StartPrice;
            addProductViewModel.Category = product.Category;
            addProductViewModel.BuyPrice = product.BuyPrice;
            return View(addProductViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AddProductViewModel addProductViewModel)
        {
            var product = new Products();
            product.Id = addProductViewModel.Id;
            product.Name = addProductViewModel.Name;
            product.ProductId = addProductViewModel.ProductId;
            product.Description = addProductViewModel.Description;
            product.BuyPrice = addProductViewModel.BuyPrice;
            product.StartPrice = addProductViewModel.StartPrice;
            product.Year = addProductViewModel.Year;
            product.Category = addProductViewModel.Category;
            addProductViewModel.categories = _categoriesRepository.AllCategories;

            if (ModelState.IsValid)
            {


                _appDbContext.Update(product);
                _appDbContext.SaveChanges();
                return RedirectToAction("ProductUpdated");


            }
            return View(addProductViewModel);
        }

        public IActionResult ProductUpdated()
        {
            ViewBag.UpdatedProductCompleteMessage = "Artikeln ändrad!";
            return View();
        }

        public IActionResult WrongPrice()
        {
            ViewBag.WrongPriceMessage = "Fel pris! Slutpriset får inte vara mindre än inköpspriset";
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ForAuctioneer(int id)
        {
            var auctioneerViewModel = new AuctioneerViewModel();
            var product = _appDbContext.Products.FirstOrDefault(x => x.Id == id);

            auctioneerViewModel.Id = product.Id;
            auctioneerViewModel.EndPrice = product.EndPrice;
            auctioneerViewModel.InStock = product.InStock;
            return View(auctioneerViewModel);

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult ForAuctioneer(AuctioneerViewModel auctioneerViewModel)
        {
            var product = _appDbContext.Products.FirstOrDefault(x => x.Id == auctioneerViewModel.Id);
            product.InStock = auctioneerViewModel.InStock;
            product.EndPrice = auctioneerViewModel.EndPrice;

            if (ModelState.IsValid)
            {
                if (!_productsRepository.IsEndPriceLower(product.BuyPrice, product.EndPrice))
                {
                    _appDbContext.Update(product);
                    _appDbContext.SaveChanges();
                    return RedirectToAction("ProductUpdated");
                }
                else
                {
                    return RedirectToAction("WrongPrice");
                }
            }
            else
            {
                return View(auctioneerViewModel);
            }

        }

    }
}
