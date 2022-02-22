using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Interfaces
{
    public interface IProductViewModelService
    {
        ProductViewModels Get(int id);
        IEnumerable<ProductViewModels> GetAll();
        void Update(ProductViewModels viewModel);
        void Insert(ProductViewModels viewModel);
        void Delete(int id);

    }
}
