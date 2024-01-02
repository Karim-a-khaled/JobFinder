using JobFinder.Data;
using JobFinder.Entities.DTOs;
using JobFinder.Entities.Entities.UserManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobFinder.Service
{
    public class AccountService
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AccountService(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }


        public async Task<User> Register(RegisterationDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user != null)
                return null;

            //byte[] passwordHash;
            //CreatePasswordHash(request.Password, out passwordHash);

            user = new User
            {
                Email = request.Email,
                //Password = Convert.ToBase64String(passwordHash), 
                IsCompany = request.isCompany,
                Password = request.Password, 
                CreationDate = DateTime.Now
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var profile = new UserFactory().DeterminUser(request.isCompany);
            profile.UserId = user.Id;

            await _context.AddAsync(profile);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> Login(LoginDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user is null)
                return null;

            //byte[] storedPasswordHash = Convert.FromBase64String(user.Password); 
            //if (!VerifyPasswordHash(request.Password, storedPasswordHash))
            //    return null;

            if (user.Password != request.Password)
                return null;

            string token = CreateToken(user);
            return token;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.IsCompany? "JobSeeker" : "Company")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        
        /*public void CreatePasswordHash(string password, out byte[] passwordHash)
        //{
        //    using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(password)))
        //    {
        //        passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //    }
        //}
        //public bool VerifyPasswordHash(string password, byte[] passwordHash)
        //{
        //    var hash = Encoding.UTF8.GetString(passwordHash);
        //    return BCrypt.Net.BCrypt.Verify(password, hash);
        //}
        */
    }
}
