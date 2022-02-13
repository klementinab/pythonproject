using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Products;
using FruitsTraceabilitySystem.Application.ViewModels.Products;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Products;

namespace FruitsTraceabilitySystem.Application.Services.Products
{
    public class ProductService : IProductService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<ProductViewModel> GetAll(string? includeProperties = null)
        {
            var products = _unitOfWork.Product.GetAll(includeProperties);
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        public ProductViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var products = _unitOfWork.Product.GetFirstOrDefault(x => x.Id == Id, includeProperties: "Category");
            return _mapper.Map<ProductViewModel>(products);
        }
        public void Add(ProductViewModel productView)
        {
            var productData = _mapper.Map<Product>(productView);
            _unitOfWork.Product.Add(productData);
        }
        public void Update(ProductViewModel productView)
        {
            var productData = _mapper.Map<Product>(productView);
            _unitOfWork.Product.Update(productData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Product.Delete(Id);
        }
        #endregion
    }
}
