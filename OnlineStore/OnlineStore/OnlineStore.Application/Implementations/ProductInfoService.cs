using AutoMapper;
using OnlineStore.Application.Interfaces;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Exceptions;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Implementations
{
    public class ProductInfoService : IProductInfoService
    {
        private readonly IProductCathegoryRepository _productCathegoryRepository;
        private readonly IProductStatusRepository _productStatusRepository;
        private readonly IMapper _mapper;



        public ProductInfoService(IProductCathegoryRepository productCathegoryRepository, IProductStatusRepository productStatusRepository, IMapper mapper)
        {
            _productCathegoryRepository = productCathegoryRepository;
            _productStatusRepository = productStatusRepository;
            _mapper = mapper;
        }

        public ProductCathegoryViewModel CreateCathegory(ProductCathegoryViewModel newCathegory)
        {
            var mappedCathegory = _mapper.Map<ProductCathegory>(newCathegory);
            _productCathegoryRepository.CreateCathegory(mappedCathegory);
            return newCathegory;
        }

        public ProductStatusViewModel CreateStatus(ProductStatusViewModel newStatus)
        {
            var mappedStatus = _mapper.Map<ProductStatus>(newStatus);
            _productStatusRepository.CreateStatus(mappedStatus);
            return newStatus;
        }

        public void DeleteCathegoryById(int id)
        {
            var cathegory = _productCathegoryRepository.GetById(id);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");
            _productCathegoryRepository.DeleteCathegory(cathegory);
        }

        public void DeleteCathegoryByName(string cathegoryName)
        {
            var cathegory = _productCathegoryRepository.GetByName(cathegoryName);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");
            _productCathegoryRepository.DeleteCathegory(cathegory);
        }

        public void DeleteStatusById(int id)
        {
            var status = _productStatusRepository.GetById(id);
            if (status == null)
                throw new NotFoundException("Status not found.");
            _productStatusRepository.DeleteStatus(status);
        }

        public void DeleteStatusByName(string statusName)
        {
            var status = _productStatusRepository.GetByName(statusName);
            if (status == null)
                throw new NotFoundException("Status not found.");
            _productStatusRepository.DeleteStatus(status);
        }

        public List<ProductCathegoryViewModel> GetAllCathegories()
        {
            var allCathegories = _productCathegoryRepository.GetAll();
            if(!allCathegories.Any())
                throw new NotFoundException("Cathegories not found.");

            var mappedCathegories = allCathegories.Select(x => _mapper.Map<ProductCathegoryViewModel>(x)).ToList();
            return mappedCathegories;
        }

        public List<ProductStatusViewModel> GetAllStatuses()
        {
            var allStatuses = _productStatusRepository.GetAll();
            if (!allStatuses.Any())
                throw new NotFoundException("Statuses not found.");

            var mappedStatuses = allStatuses.Select(x => _mapper.Map<ProductStatusViewModel>(x)).ToList();
            return mappedStatuses;
        }

        public ProductCathegoryViewModel GetCathegoryById(int id)
        {
            var cathegory = _productCathegoryRepository.GetById(id);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");
            return _mapper.Map<ProductCathegoryViewModel>(cathegory);
        }

        public ProductCathegoryViewModel GetCathegoryByName(string cathegoryName)
        {
            var cathegory = _productCathegoryRepository.GetByName(cathegoryName);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");
            return _mapper.Map<ProductCathegoryViewModel>(cathegory);
        }

        public ProductStatusViewModel GetCStatusyById(int id)
        {
            var status = _productStatusRepository.GetById(id);
            if (status == null)
                throw new NotFoundException("Status not found.");
            return _mapper.Map<ProductStatusViewModel>(status);
        }

        public ProductStatusViewModel GetStatusByName(string statusName)
        {
            var status = _productStatusRepository.GetByName(statusName);
            if (status == null)
                throw new NotFoundException("Status not found.");
            return _mapper.Map<ProductStatusViewModel>(status);
        }

        public ProductCathegoryViewModel UpdateCathegoryById(ProductCathegoryViewModel updatedCathegory, int id)
        {
            var cathegory = _productCathegoryRepository.GetById(id);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");

            cathegory.CathegoryName = updatedCathegory.CathegoryName;

            _productCathegoryRepository.UpdateCathegory(cathegory);
            return updatedCathegory;
        }

        public ProductCathegoryViewModel UpdateCathegoryByName(ProductCathegoryViewModel updatedCathegory, string name)
        {
            var cathegory = _productCathegoryRepository.GetByName(name);
            if (cathegory == null)
                throw new NotFoundException("Cathegory not found.");

            cathegory.CathegoryName = updatedCathegory.CathegoryName;

            _productCathegoryRepository.UpdateCathegory(cathegory);
            return updatedCathegory;
        }

        public ProductStatusViewModel UpdateStatusById(ProductStatusViewModel updatedStatus, int id)
        {
            var status = _productStatusRepository.GetById(id);
            if(status == null)
                throw new NotFoundException("Status not found.");

            status.StatusName = updatedStatus.StatusName;

            _productStatusRepository.UpdateStatus(status);

            return updatedStatus;
        }

        public ProductStatusViewModel UpdateStatusByName(ProductStatusViewModel updatedStatus, string statusName)
        {
            var status = _productStatusRepository.GetByName(statusName);
            if (status == null)
                throw new NotFoundException("Status not found.");

            status.StatusName = updatedStatus.StatusName;

            _productStatusRepository.UpdateStatus(status);

            return updatedStatus;
        }
    }
}
