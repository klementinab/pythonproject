using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Locations;
using FruitsTraceabilitySystem.Application.ViewModels.Locations;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Locations;

namespace FruitsTraceabilitySystem.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public LocationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<LocationViewModel> GetAll(string? includeProperties = null)
        {
            var locations = _unitOfWork.Locations.GetAll(includeProperties);
            return _mapper.Map<List<LocationViewModel>>(locations);
        }
        public LocationViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var locations = _unitOfWork.Locations.GetFirstOrDefault(x => x.Id == Id);
            return _mapper.Map<LocationViewModel>(locations);
        }
        public void Add(LocationViewModel locationView)
        {
            var locationData = _mapper.Map<Location>(locationView);
            _unitOfWork.Locations.Add(locationData);
        }
        public void Update(LocationViewModel locationView)
        {
            var locationData = _mapper.Map<Location>(locationView);
            _unitOfWork.Locations.Update(locationData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Locations.Delete(Id);
        }
        #endregion
    }
}
