using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Sortings;
using FruitsTraceabilitySystem.Application.ViewModels.Sortings;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Sortings;

namespace FruitsTraceabilitySystem.Application.Services.Sortings
{
    public class SortingService : ISortingService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public SortingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<SortingViewModel> GetAll(string? includeProperties = null)
        {
            var sortings = _unitOfWork.Sorting.GetAll(includeProperties);
            return _mapper.Map<List<SortingViewModel>>(sortings);
        }
        public SortingViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var sortings = _unitOfWork.Sorting.GetFirstOrDefault(x => x.Id == Id, includeProperties: "Harvest,User");
            return _mapper.Map<SortingViewModel>(sortings);
        }
        public void Add(SortingViewModel sortingView)
        {
            var sortingData = _mapper.Map<Sorting>(sortingView);
            _unitOfWork.Sorting.Add(sortingData);
        }
        public void Update(SortingViewModel sortingView)
        {
            var sortingData = _mapper.Map<Sorting>(sortingView);
            _unitOfWork.Sorting.Update(sortingData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Sorting.Delete(Id);
        }
        #endregion
    }
}
