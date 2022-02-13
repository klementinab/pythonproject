using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Harvests;
using FruitsTraceabilitySystem.Application.ViewModels.Harvests;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Harvests;

namespace FruitsTraceabilitySystem.Application.Services.Harvests
{
    public class HarvestService : IHarvestService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public HarvestService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<HarvestViewModel> GetAll(string? includeProperties = null)
        {
            var harvests = _unitOfWork.Harvest.GetAll(includeProperties);
            return _mapper.Map<List<HarvestViewModel>>(harvests);
        }
        public HarvestViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var harvests = _unitOfWork.Harvest.GetFirstOrDefault(x => x.Id == Id, includeProperties: "Product,User");
            return _mapper.Map<HarvestViewModel>(harvests);
        }
        public void Add(HarvestViewModel harvestView)
        {
            var harvestData = _mapper.Map<Harvest>(harvestView);
            _unitOfWork.Harvest.Add(harvestData);
        }
        public void Update(HarvestViewModel harvestView)
        {
            var harvestData = _mapper.Map<Harvest>(harvestView);
            _unitOfWork.Harvest.Update(harvestData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Harvest.Delete(Id);
        }
        #endregion
    }
}
