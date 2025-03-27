using Azure.Core;
using Data_Access_Layer.DBContext;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Responses;
using Microsoft.EntityFrameworkCore;
using SkinCare_Product_Sale.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly SkincareManagementContext _context;

        public AccountService(SkincareManagementContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStaffAsync(string username, string password)
        {
            if (_context.Accounts.Any(a => a.Username == username))
            {
                return false; // Username already exists
            }

            var newStaff = new Account
            {
                Username = username,
                Password = password,
                RoleId = 2, // Assuming 2 is the role ID for staff
            };

            _context.Accounts.Add(newStaff);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            if (await IsUsernameExistAsync(request.Username))
                return false;

            var role = await FindRoleByNameRoleAsync("Customer");
            var account = new Account
            {
                Username = request.Username,
                Password = request.Password,
                Role = role
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var customer = new Customer
            {
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                AccountId = account.AccountId
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();


            return true;
        }

        public async Task<LoginResponse?> LoginAsync(LoginRequest request)
        {
            var user = await FindByUsernameAsync(request.Username);
            if (user == null || (user.Password != request.Password))
            {
                return null;
            }

            return new LoginResponse
            {
                AccountId = user.AccountId,
                Username = user.Username,
                RoleName = user?.Role?.RoleName ?? "Customer",
                IsActive = user.IsActive
            };
        }

        public async Task<bool> IsUsernameExistAsync(string username)
        {
            var user = await FindByUsernameAsync(username);
            return user != null;
        }

        public async Task<Role> FindRoleByIdAsync(int id)
        {
            return await _context.Roles.FirstAsync(r => r.RoleId == id);
        }

        public async Task<Account?> FindByUsernameAsync(string username)
        {
            return await _context.Accounts
                .Include(a => a.Employees)
                .Include(a => a.Customers)
                .Include(a => a.Role)
                .FirstOrDefaultAsync(r => r.Username == username);
        }

        public async Task<Role> FindRoleByNameRoleAsync(string name)
        {
            return await _context.Roles.FirstAsync(r => r.RoleName == name);
        }

        public async Task<Account> UpdateAsync(Account account)
        {
            _context.Update(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Customer> FindCustomerByIdAsync(int id)
        {
            return await _context.Customers.FirstAsync(c => c.AccountId == id);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .Include(c => c.Account)
                .ToListAsync();
        }

        public async Task<List<Account>> GetAllStaffAsync()
        {
            return await _context.Accounts
                .Where(a => a.RoleId == 2)
                .ToListAsync();
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.AccountId == id);
            if (customer == null)
                return false;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            // Also delete the associated account
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> ToggleAccountStatus(int accountId)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
                return false;

            account.IsActive = !account.IsActive;
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
