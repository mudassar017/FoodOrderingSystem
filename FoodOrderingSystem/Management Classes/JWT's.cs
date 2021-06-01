using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingSystem.Management_Classes
{
    public class JWT_s
    {
        //public static string GenerateJSONWebToken(Student userInfo, IConfiguration config)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    //var claims = new[] {
        //    //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username) };

        //    var claims = new[] {
        //     new Claim("UserId", userInfo.StudentId.ToString()),
        //     new Claim("UserName", userInfo.UserName.ToString())

        //    };


        //    var token = new JwtSecurityToken(config["Jwt:Issuer"],
        //      config["Jwt:Issuer"],
        //      claims,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
