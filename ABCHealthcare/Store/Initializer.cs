using ABCHealthcare.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCHealthcare.Store
{
    public static class Initializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "Sahil",
                    Email = "sahil123@test.com"
                };
                await userManager.CreateAsync(user, "Password@12345");
                await userManager.AddToRoleAsync(user, "User");


                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin123@test.com"
                };
                await userManager.CreateAsync(admin, "Password@12345");
                await userManager.AddToRolesAsync(admin, new[] { "User", "Admin" });

            }

            if (context.Medicines.Any()) return;
            var medicines = new List<Medicine>
            {
                new Medicine
                {
                    Name = "Crocin",
                    Price = 20,
                    Image = "https://5.imimg.com/data5/OU/XS/MY-53366293/crocin-500x500.jpg",
                    Seller = "XYZ Suppliers",
                    Description = "Crocin Pain Relief provides targeted pain relief. It provides symptomatic relief from mild to moderate pain e.g from headache, migraine, toothache.",
                    Quantity = 15,
                    Category = "Painkiller"
                },

                new Medicine
                {
                    Name = "Paracetamol",
                    Price = 18,
                    Image = "https://5.imimg.com/data5/SELLER/Default/2022/9/IV/UY/CG/75459511/500mg-paracetamol-tablet-250x250.jpg",
                    Seller = "XYZ Suppliers",
                    Description = "Paracetamol is a common painkiller used to treat aches and pain. It can also be used to reduce a high temperature.",
                    Quantity = 12,
                    Category = "Painkiller"
                },

                new Medicine
                {
                    Name = "Azithral 500",
                    Price = 25,
                    Image = "https://newassets.apollo247.com/pub/media/catalog/product/a/z/azi0013_1.jpg",
                    Seller = "ABC Suppliers",
                    Description = "Azithral 500 Tablet is an antibiotic used to treat various types of bacterial infections of the respiratory tract, ear, nose, throat, lungs, skin, and eye in adults and children.",
                    Quantity = 5,
                    Category = "Antibiotic"
                },

                new Medicine
                {
                    Name = "Azee 500",
                    Price = 20,
                    Image = "https://5.imimg.com/data5/SELLER/Default/2022/4/MG/JO/VM/31640038/medzee-500-tablets-250x250.jpg",
                    Seller = "ABC Suppliers",
                    Description = "Azee 500 Tablet is an antibiotic used to treat various types of bacterial infections of the respiratory tract, ear, nose, throat, lungs, skin, and eye in adults and children. It is also effective in typhoid fever and some sexually transmitted diseases like gonorrhea.",
                    Quantity = 5,
                    Category = "Antibiotic"
                },

                new Medicine
                {
                    Name = "Avil Injection",
                    Price = 5,
                    Image = "https://5.imimg.com/data5/JH/HI/MG/SELLER-16645300/avil-inj-250x250.jpg",
                    Seller = "PQR Suppliers",
                    Description = "Avil Injection is an antiallergic medication. It is used to treats symptoms of allergic conditions caused by insect bites/stings, certain medicines, or hives (rashes, swelling, etc.).",
                    Quantity = 1,
                    Category = "Injection"
                },

                new Medicine
                {
                    Name = "Dolo 650",
                    Price = 26,
                    Image = "https://5.imimg.com/data5/SU/FN/MY-53366293/dolo-65-250x250.jpg",
                    Seller = "XYZ Suppliers",
                    Description = "Dolo 650 Tablet helps relieve pain and fever by blocking the release of certain chemical messengers responsible for fever and pain. It is used to treat headaches, migraine, nerve pain, toothache, sore throat, period (menstrual) pains, arthritis, muscle aches, and the common cold.",
                    Quantity = 15,
                    Category = "Painkiller"
                },

                new Medicine
                {
                    Name = "Cefix 200",
                    Price = 10,
                    Image = "https://5.imimg.com/data5/SELLER/Default/2021/10/DZ/UE/PQ/63235102/cefix-cefixime-200mg-tablets-250x250.jpg",
                    Seller = "ABC Suppliers",
                    Description = "Cefix 200 Tablet is an antibiotic belonging that is used to treat a variety of bacterial infections. It is effective in infections of the respiratory tract (eg. pneumonia), urinary tract, ear, nasal sinus, throat, and some sexually transmitted diseases.",
                    Quantity = 10,
                    Category = "Antibiotic "
                },

                new Medicine
                {
                    Name = "Enzoflam",
                    Price = 15,
                    Image = "https://5.imimg.com/data5/SELLER/Default/2022/5/KS/TE/HE/136261961/n2gesepigqmuphnnwupw-250x250.jpg",
                    Seller = "XYZ Suppliers",
                    Description = "Enzoflam Tablet is a pain-relieving medicine. It helps in relieving moderate pain and reducing fever. It is used in various conditions such as muscle ache, back pain, joint pain, menstrual cramps, and toothache.",
                    Quantity = 10,
                    Category = "Painkiller "
                },

            };

            foreach (var medicine in medicines)
            {
                context.Medicines.Add(medicine);
            }

            context.SaveChanges();
        }
    }
}
