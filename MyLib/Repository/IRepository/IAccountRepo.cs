using MyLib.Models.Entities;
using MyLib.Models.ModelViews;
using MyLib.Repository.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLib.Repository.IRepository
{
    public interface IAccountRepo : IGenericRepo<Account>
    {
        AccountView CreateAccount(AccountView accountView);
        AccountView CreateAccount_CUSTOMER(AccountView customer);
        AccountView GetAccount(int Id);
        List<AccountView> GetAllEmployee();
        public Account Login(AccountView accountView);
        AccountView LoginAccount_CUSTOMER(AccountView customer);
        bool UpdateAccount(AccountView accountView);
        bool UpdateActive(int Id, bool Active);
        bool UpdateStatus(int[] arrId);
    }
}
