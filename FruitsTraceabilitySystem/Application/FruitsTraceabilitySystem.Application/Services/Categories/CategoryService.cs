using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Categories;
using FruitsTraceabilitySystem.Application.ViewModels.Categories;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Categories;

namespace FruitsTraceabilitySystem.Application.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<CategoryViewModel> GetAll(string? includeProperties = null)
        {
            var categories = _unitOfWork.Category.GetAll(includeProperties);
            return _mapper.Map<List<CategoryViewModel>>(categories);
        }
        public CategoryViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var categories = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == Id);
            return _mapper.Map<CategoryViewModel>(categories);
        }
        public void Add(CategoryViewModel categoryView)
        {
            var categoryData = _mapper.Map<Category>(categoryView);
            _unitOfWork.Category.Add(categoryData);
        }
        public void Update(CategoryViewModel categoryView)
        {
            var categoryData = _mapper.Map<Category>(categoryView);
            _unitOfWork.Category.Update(categoryData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Category.Delete(Id);
        }
        #endregion
    }
}
