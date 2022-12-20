using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IProductInfoService
    {
        // Cathegories
        ProductCathegoryViewModel CreateCathegory(ProductCathegoryViewModel newCathegory);//
        ProductCathegoryViewModel UpdateCathegoryByName(ProductCathegoryViewModel updatedCathegory, string name); //
        ProductCathegoryViewModel UpdateCathegoryById(ProductCathegoryViewModel updatedCathegory, int id);//
        void DeleteCathegoryById(int id);
        void DeleteCathegoryByName(string cathegoryName);
        ProductCathegoryViewModel GetCathegoryByName (string cathegoryName);//
        ProductCathegoryViewModel GetCathegoryById (int id);//
        List<ProductCathegoryViewModel> GetAllCathegories();//


        // Cathegories
        ProductStatusViewModel CreateStatus(ProductStatusViewModel newStatus);
        ProductStatusViewModel UpdateStatusByName(ProductStatusViewModel updatedStatus, string statusName);
        ProductStatusViewModel UpdateStatusById(ProductStatusViewModel updatedStatus, int id);
        void DeleteStatusById(int id);
        void DeleteStatusByName(string statusName);
        ProductStatusViewModel GetStatusByName(string statusName);
        ProductStatusViewModel GetCStatusyById(int id);
        List<ProductStatusViewModel> GetAllStatuses();
    }
}
