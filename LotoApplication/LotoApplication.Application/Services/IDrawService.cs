using LotoApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface IDrawService
    {
        DrawDto GenerateDrawNumbers(int adminId);
    }
}
