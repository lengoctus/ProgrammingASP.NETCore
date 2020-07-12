using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyLib.Library;
using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using MyLib.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xaml.Permissions;

namespace MyLib.Repository.CsRepository
{
    public class AccountRepo : GenericRepo<Account>, IAccountRepo
    {
        private ConnectDbContext _db;
        public AccountRepo(ConnectDbContext db) : base(db)
        {
            _db = db;
        }

        #region Login 
        public Account Login(AccountView accountView)
        {
            accountView.Password = EnCryptPass.Enscrypt(accountView.Email, accountView.Password);
            var acc = GetAllNTU().AsNoTracking().FirstOrDefault(p => p.Email.ToLower() == accountView.Email.ToLower().Trim() && p.Password == accountView.Password);
            if (acc == null)
            {
                return null;
            }

            return acc;
        }
        #endregion

        #region Create Employee
        private string GetLastEmpCode()
        {
            try
            {
                return _db.Account.FromSqlRaw("SELECT * FROM Account WHERE [Status] = 1 AND [Role] = 2").ToList().LastOrDefault().Code;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public AccountView CreateAccount(AccountView accountView)
        {
            if (CheckAccount(accountView) == true)
            {
                var lastempCode = GetLastEmpCode();
                var accNew = new Account
                {
                    Code = lastempCode != null ? GenerateCode.GenerateEmpCodeNTU(lastempCode, "EMP") : "EMP00000001",
                    Email = accountView.Email,
                    FullName = accountView.FullName,
                    Password = accountView.Password,
                    Image = accountView.Image,
                    Role = 2,
                    Active = true,
                    Status = true
                };
                var account = CreateNTU(accNew).Result;
                accountView.Id = account.Id;
                accountView.Code = account.Code;


                return accountView;
            }
            return null;

        }

        private bool CheckAccount(AccountView accountView)
        {
            var acc = GetAllNTU().FirstOrDefault(p => p.Email.ToLower() == accountView.Email.ToLower());
            if (acc != null) return false;

            return true;
        }
        #endregion

        #region Get All Employee
        public List<AccountView> GetAllEmployee()
        {
            return GetAllNTU().Where(p => p.Status == true && p.Role == 2).Select(p => new AccountView
            {
                Id = p.Id,
                Email = p.Email,
                Code = p.Code,
                Image = p.Image,
                FullName = p.FullName,
                Active = p.Active ?? false
            }).ToList();
        }
        #endregion

        #region Get Account by Id
        public AccountView GetAccount(int Id)
        {
            var acc = GetByIdNTU(Id).Result;
            if (acc != null)
            {
                return new AccountView
                {
                    Id = acc.Id,
                    FullName = acc.FullName,
                    Email = acc.Email,
                    Image = acc.Image,
                    Code = acc.Code
                };
            }
            return null;
        }
        #endregion

        #region Update Account
        private bool CheckUpdateAccount(AccountView accountView)
        {
            return GetAllNTU().FirstOrDefault(p => p.Id != accountView.Id && p.Email.ToLower() == accountView.Email.ToLower()) == null ? true : false;
        }

        public bool UpdateAccount(AccountView accountView)
        {
            if (!CheckUpdateAccount(accountView))
            {
                var acc = GetByIdNTU(accountView.Id).Result;

                if (acc == null) return false;

                if (accountView.Image != null)
                {
                    acc.Image = accountView.Image;
                }

                acc.FullName = accountView.FullName;
                acc.Email = accountView.Email;


                return UpdateNTU(acc).Result;
            }
            return false;
        }
        #endregion

        #region Update Status false for Account
        public bool UpdateStatus(int[] arrId)
        {
            var acc = GetAllNTU().Where(p => arrId.Contains(p.Id)).ToList();
            foreach (var item in acc)
            {
                item.Status = false;
            }
            return UpdateMultiFieldNTU(acc).Result;
        }
        #endregion

        #region Update Active
        public bool UpdateActive(int Id, bool Active)
        {
            var acc = GetByIdNTU(Id).Result;
            if (acc != null)
            {
                acc.Active = Active;
            }

            return UpdateNTU(acc).Result;
        }
        #endregion



        //==================================  CUSTOMER    ====================================
        public AccountView CreateAccount_CUSTOMER(AccountView customer)
        {
            if (CheckAccount_CUSTOMER(customer))
            {
                customer.Password = EnCryptPass.Enscrypt(customer.Email, customer.Password);
                var customer_return = CreateNTU(new Account { Email = customer.Email, Password = customer.Password, Role = 3, Code = customer.Code, Image = customer.Image, FullName = customer.FullName, Active = true, Status = true }).Result;
                customer.Id = customer_return.Id;
                return customer;

            }
            return null;
        }

        private bool CheckAccount_CUSTOMER(AccountView customer)
        {
            var cus = GetAllNTU().FirstOrDefault(p => p.Email.ToLower() == customer.Email.ToLower());
            if (cus == null)
            {
                return true;
            }
            return false;
        }

        public string GetLastCustomerCode() {
            var cus = _db.Account.FromSqlRaw("SELECT [CODE] FROM ACCOUNT WHERE [STATUS] = 1 AND [ROLE] = 3");
                return null;
        }

        public AccountView LoginAccount_CUSTOMER(AccountView customer)
        {
            customer.Password = EnCryptPass.Enscrypt(customer.Email, customer.Password);
            var check = GetAllNTU().FirstOrDefault(p => p.Email.ToLower() == customer.Email.ToLower() && p.Password == customer.Password && p.Role == 3);
            if (check != null)
            {
                customer.Id = check.Id;
                customer.FullName = check.FullName;
                customer.Role = check.Role;
                return customer;
            }
            return null;
        }
    }
}
