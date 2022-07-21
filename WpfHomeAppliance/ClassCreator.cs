using System;
using WpfHomeAppliance.DataModel;

namespace WpfHomeAppliance
    {
    public class ClassCreator
        {

        internal static ConnHelper CreateConnection()
            { 
            return new ConnHelper();    
            }
        internal static Brand CreateBrand()
            {
            return new Brand();
            }
        internal static Category CreateCategory()
            {
            return new Category();
            }
        internal static User CreateUser()
            {
            return new User();
            }

        internal static Product CreateProduct()
            {
            return new Product();
            }
        }
    }
