namespace SevShop.Application.Shared;

public static class Permissions
{
    public static class Account
    {
        public const string Register = "Account.Register"; 
        public const string Login = "Account.Login";  
        public const string RefreshToken = "Account.RefreshToken"; 
        public const string AddRole = "Account.AddRole"; 
        public const string ConfirmEmail = "Account.ConfirmEmail"; 
        public static List<string> All = new()
        {
            Register,
            Login,
            RefreshToken,
            AddRole,
            ConfirmEmail
        };
    }

    public static class Category
    {
        public const string GetAll = "Category.GetAll";   
        public const string GetById = "Category.GetById"; 
        public const string Create = "Category.Create";  
        public const string Update = "Category.Update"; 
        public const string Delete = "Category.Delete";   
        public static List<string> All = new()
        {
            GetAll,
            GetById,
            Create,
            Update,
            Delete
        };
    }

    public static class FileUpload
    {
        public const string Upload = "FileUpload.Upload";  
    }

    public static class Image
    {
        public const string GetAll = "Image.GetAll";
        public const string GetById = "Image.GetById";
        public const string Create = "Image.Create";    
        public const string Update = "Image.Update";    
        public const string Delete = "Image.Delete";   
        public static List<string> All = new()
        {
            GetAll,
            GetById,
            Create,
            Update,
            Delete
        };
    }

    public static class OrderProduct
    {
        public const string Create = "OrderProduct.Create"; 
        public const string Update = "OrderProduct.Update";  
        public const string Delete = "OrderProduct.Delete"; 
        public const string GetAll = "OrderProduct.GetAll";
        public const string GetById = "OrderProduct.GetById";

        public static List<string> All = new()
        {
            Create,
            Update,
            Delete,
            GetAll,
            GetById
        };
    }

    public static class Order
    {
        public const string Create = "Order.Create";
        public const string GetMyOrders = "Order.GetMyOrders";
        public const string GetSales = "Order.GetSales";
        public const string GetById = "Order.GetById"; 

        public static List<string> All = new()
        {
            Create,
            GetMyOrders,
            GetSales,
            GetById
        };
    }

    public static class Product
    {
        public const string GetAll = "Product.GetAll"; 
        public const string GetById = "Product.GetById";
        public const string Create = "Product.Create";
        public const string Update = "Product.Update";
        public const string Delete = "Product.Delete";
        public const string GetMyProducts = "Product.GetMyProducts";
        public const string AddToFavorite = "Product.AddToFavorite"; 
        public const string RemoveFromFavorite = "Product.RemoveFromFavorite";
        public const string GetMyFavorites = "Product.GetMyFavorites";  

        public static List<string> All = new()
        {
            GetAll,
            GetById,
            Create,
            Update,
            Delete,
            GetMyProducts,
            AddToFavorite,
            RemoveFromFavorite,
            GetMyFavorites
        };
    }

    public static class Review
    {
        public const string GetByProductId = "Review.GetByProductId";
        public const string Create = "Review.Create";
        public const string Update = "Review.Update";
        public const string Delete = "Review.Delete";

        public static List<string> All = new()
        {
            GetByProductId,
            Create,
            Update,
            Delete
        };
    }

    public static class Role
    {
        public const string Create = "Role.Create"; 
        public const string Delete = "Role.Delete"; 
        public const string GetAllPermissions = "Role.GetAllPermissions"; 

        public static List<string> All = new()
        {
            Create,
            Delete,
            GetAllPermissions
        };
    }
}

