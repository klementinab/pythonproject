using AutoMapper;
using FruitsTraceabilitySystem.Application.Interfaces.Packages;
using FruitsTraceabilitySystem.Application.ViewModels.Packages;
using FruitsTraceabilitySystem.Domain.Interfaces.UnitOfWork;
using FruitsTraceabilitySystem.Domain.Models.Packages;

namespace FruitsTraceabilitySystem.Application.Services.Packages
{
    public class PackageService : IPackageService
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructors
        public PackageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        #endregion

        #region Methods
        public IEnumerable<PackageViewModel> GetAll(string? includeProperties = null)
        {
            var packages = _unitOfWork.Package.GetAll(includeProperties);
            return _mapper.Map<List<PackageViewModel>>(packages);
        }
        public PackageViewModel GetFirstOrDefault(int? Id, string? includeProperties = null)
        {
            var packages = _unitOfWork.Package.GetFirstOrDefault(x => x.Id == Id);
            return _mapper.Map<PackageViewModel>(packages);
        }
        public void Add(PackageViewModel packageView)
        {
            var packageData = _mapper.Map<Package>(packageView);
            _unitOfWork.Package.Add(packageData);
        }
        public void Update(PackageViewModel packageView)
        {
            var packageData = _mapper.Map<Package>(packageView);
            _unitOfWork.Package.Update(packageData);
        }
        public void Delete(int? Id)
        {
            _unitOfWork.Package.Delete(Id);
        }
        #endregion
    }
}
