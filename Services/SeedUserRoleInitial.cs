using System;
using Microsoft.AspNetCore.Identity;

namespace SistemaDeCompras.Services
{
    public class SeedUserRoleInitial:ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManage ){
           _userManager=userManager;
           _roleManager=roleManage;
        }

        public void SeedRoles(){

             //Verifica se a role existe, caso não exista a mesma é criada
            if(!_roleManager.RoleExistsAsync("Member").Result){
                IdentityRole role=new IdentityRole();
                role.Name="Member";
                role.NormalizedName="MEMBER";
                IdentityResult roleResult=_roleManager.CreateAsync(role).Result;
            }

             if(!_roleManager.RoleExistsAsync("Admin").Result){
                IdentityRole role=new IdentityRole();
                role.Name="Admin";
                role.NormalizedName="ADMIN";
                IdentityResult roleResult=_roleManager.CreateAsync(role).Result;
            }

        }

        public void SeedUsers(){

            if(_userManager.FindByNameAsync("usuario@localhost").Result==null){
               
               IdentityUser user=new IdentityUser();

               user.UserName="usuario@localhost";
               user.Email="usuario@localhost";
               user.NormalizedUserName="USUARIO@LOCALHOST";
               user.NormalizedEmail="USUARIO@LOCALHOST";
               user.EmailConfirmed=true;
               user.LockoutEnabled=false;
               user.SecurityStamp=Guid.NewGuid().ToString();

               IdentityResult result=_userManager.CreateAsync(user, "Numsey#2022").Result;

               if(result.Succeeded){
                  _userManager.AddToRoleAsync(user, "Member").Wait();
               }
            }

              if(_userManager.FindByNameAsync("admin@localhost").Result==null){
               
               IdentityUser user=new IdentityUser();

               user.UserName="admin@localhost";
               user.Email="admin@localhost";
               user.NormalizedUserName="ADMIN@LOCALHOST";
               user.NormalizedEmail="ADMIN@LOCALHOST";
               user.EmailConfirmed=true;
               user.LockoutEnabled=false;
               user.SecurityStamp=Guid.NewGuid().ToString();

               IdentityResult result=_userManager.CreateAsync(user, "Numsey#2022").Result;

               if(result.Succeeded){
                  _userManager.AddToRoleAsync(user, "Admin").Wait();
               }
            }

            
            
        }
        
    }
}