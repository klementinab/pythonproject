using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Packangings;
using FruitsTraceabilitySystem.Application.ViewModels.Packangings;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Packangins;

namespace FruitsTraceabilitySystem.Application.Services.Packangings
{
    public class PackangingService : IPackangingService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public PackangingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<PackangingViewModel> GetAll(string? includeProperties = null)
        {
            var packangings = _unitOfWork.Packanging.GetAll(includeProperties);
            return _mapper.Map<List<PackangingViewModel>>(packangings);
        }
        public PackangingViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var packangings = _unitOfWork.Packanging.GetFirstOrDefault(x => x.Id == Id);
            return _mapper.Map<PackangingViewModel>(packangings);
        }
        public void Add(PackangingViewModel packangingView)
        {
            var packageData = _mapper.Map<Packanging>(packangingView);
            _unitOfWork.Packanging.Add(packageData);
        }
        public void Update(PackangingViewModel packangingView)
        {
            var packageData = _mapper.Map<Packanging>(packangingView);
            _unitOfWork.Packanging.Update(packageData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Packanging.Delete(Id);
        }
        #endregion
    }
}
