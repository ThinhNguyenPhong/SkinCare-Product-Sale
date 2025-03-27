using Data_Access_Layer.Entities;
using Data_Access_Layer.Responses;
using SkinCare_Product_Sale.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.AccountServices
{
        public interface IAccountService
        {
        Task<bool> AddStaffAsync(string username, string password);
            Task<bool> RegisterAsync(RegisterRequest request);
            Task<LoginResponse> LoginAsync(LoginRequest request);
            Task<bool> IsUsernameExistAsync(string username);
            Task<Role> FindRoleByIdAsync(int id);
            Task<Role> FindRoleByNameRoleAsync(string name);
            Task<Account?> FindByUsernameAsync(string username);
            Task<Account> UpdateAsync(Account account);
        Task<Customer> FindCustomerByIdAsync(int id);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> ToggleAccountStatus(int accountId);
        Task<List<Account>> GetAllStaffAsync();

    }
}
