using DatingApp.Application.DTO;
using DatingApp.Application.Interfaces;
using DatingApp.Core.DTO;
using DatingApp.Core.Entities;
using DatingApp.Core.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly ISendMailService _sendMailService;
        public AccountService(IUserRepository userRepository, ITokenService tokenService, ISendMailService sendMailService)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _sendMailService = sendMailService;
        }
        public async Task<UserDto> Login(LoginDto loginDto)
        {
            //accountService.login(username, password);
            //var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            var user = await _userRepository.GetByUsername(loginDto.Username);

            if (user == null) return new UserDto { IsSuccess = false };

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return new UserDto { IsSuccess = false };
                }
            }

            return new UserDto
            {
                //Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                IsSuccess = true

            };
        }

        public async Task Register(RegisterDto registerDto)
        {
            var nameOfProfilePic = string.Empty;

            if (registerDto.Avatar != null)
            {
                var folderSave = Path.Combine("Share", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderSave);
                nameOfProfilePic = Guid.NewGuid().ToString() + "-" + registerDto.Avatar.FileName;
                var fullPath = Path.Combine(pathToSave, nameOfProfilePic);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    registerDto.Avatar.CopyTo(stream);
                }
            }

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Avatar = nameOfProfilePic,
            };

            _userRepository.Insert(user);
            _userRepository.Save();

            if(_userRepository.GetByUsername(user.UserName) != null)
            {
                MailContent content = new MailContent
                {
                    To = user.Email,
                    Subject = "Welcome to UNGAP",
                    Body = "<p>Your account has been created - now it will be easier than ever to share and connect with your friends and family</p>" +
                        "<br />" +
                        "<p>Here are three ways for you to get the most out of it:</p>" +
                        "<p>+Find the people you know</p>" +
                        "<p>+Upload a Profile Photo</p>" +
                        "<p>+Edit your Profile</p>"
                };
                await _sendMailService.SendMail(content);
            }          
        }

        public async Task EditProfile(ProfileDto profileDto)
        {
            string folderSave = Path.Combine("Share", "Images");
            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderSave);
            string nameOfProfilePic = null;
            string nameOfCoverPhoto = null;

            if (profileDto.Avatar != null)
            {
                nameOfProfilePic = Guid.NewGuid().ToString() + "-" + profileDto.Avatar.FileName;
                var fullPath = Path.Combine(pathToSave, nameOfProfilePic);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    profileDto.Avatar.CopyTo(stream);
                }
            }
            if (profileDto.CoverPhoto != null)
            {
                nameOfCoverPhoto = Guid.NewGuid().ToString() + "-" + profileDto.CoverPhoto.FileName;
                var fullPath = Path.Combine(pathToSave, nameOfCoverPhoto);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    profileDto.CoverPhoto.CopyTo(stream);
                }
            }

            AppUser userNeedToUpdate = await _userRepository.GetByUsername(profileDto.UserName);
            userNeedToUpdate.FirstName = profileDto.FirstName;
            userNeedToUpdate.LastName = profileDto.LastName;
            userNeedToUpdate.Email = profileDto.Email;
            userNeedToUpdate.DateOfBirth = profileDto.DateOfBirth;
            userNeedToUpdate.Gender = profileDto.Gender;
            userNeedToUpdate.Phone = profileDto.Phone;

            if (nameOfProfilePic != null) userNeedToUpdate.Avatar = nameOfProfilePic;
            if (nameOfCoverPhoto != null) userNeedToUpdate.CoverPhoto = nameOfCoverPhoto;

            _userRepository.Update(userNeedToUpdate);
            _userRepository.Save();
        }

        public async Task<ProfileInfoDto> GetUserProfile(string username)
        {
            AppUser user = await _userRepository.GetByUsername(username);
            if (user == null) { return null; }
            return new ProfileInfoDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Phone = user.Phone,
                Gender = user.Gender,
                Avatar = user.Avatar,
                CoverPhoto = user.CoverPhoto,
            };
        }
    }
}
