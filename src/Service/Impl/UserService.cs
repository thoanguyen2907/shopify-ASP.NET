using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Shopify.src.Abstraction;
using Shopify.src.DTO;
using Shopify.src.Entity;
using Shopify.src.Shared;

namespace Shopify.src.Service.Impl
{
    public class UserService : IUserService
    {
        protected IUserRepo _userRepo;
        protected IMapper _mapper;
        protected IWebHostEnvironment _environment;
        protected Cloudinary _cloudinary;

        public UserService(IUserRepo userRepo, IMapper mapper, IWebHostEnvironment environment,
        Cloudinary cloudinary)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _environment = environment;
            _cloudinary = cloudinary;
            _cloudinary.Api.Secure = true;

        }

        public async Task<UserReadDto> CreateAdminAsync(UserCreateDto createDto)
        {
            PasswordService.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Password = hashedPassword;
            user.Salt = salt;
            user.Role = Entity.Role.Admin;
            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);
        }

        public async Task<UserReadDto> CreateOneAsync(UserCreateDto createDto)
        {
            System.Console.WriteLine($"WebRootPath: {_environment.WebRootPath}");

            PasswordService.HashPassword(createDto.Password, out string hashedPassword, out byte[] salt);
            var user = _mapper.Map<UserCreateDto, User>(createDto);
            user.Password = hashedPassword;
            user.Salt = salt;
            user.Role = Entity.Role.Customer;
            user.IsOauth = false;
            System.Console.WriteLine($"user.Password {createDto.Password}");
            System.Console.WriteLine($"user.Email {createDto.Email}");
            System.Console.WriteLine($"user.Password {createDto.Name}");

            if (createDto.Image != null)
            {
                System.Console.WriteLine($"image of use {createDto.Image}");
                var uploadsFolder = Path.Combine(_environment.WebRootPath ?? Directory.GetCurrentDirectory(), "uploads");

                System.Console.WriteLine($"image of uploadsFolder {uploadsFolder}");
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + createDto.Image.FileName;
                System.Console.WriteLine($"user uniqueFileName {uniqueFileName}");
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                System.Console.WriteLine($"user filePath {filePath}");

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(uniqueFileName, createDto.Image.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };
                var uploadResult = _cloudinary.Upload(uploadParams);
                var imageUrl = uploadResult.SecureUrl.ToString();
                Console.WriteLine($"imageUrl {imageUrl}");

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await createDto.Image.CopyToAsync(fileStream);
                }
                user.Image = imageUrl;
            }
            var savedUser = await _userRepo.CreateOneAsync(user);
            return _mapper.Map<User, UserReadDto>(savedUser);
        }

        public async Task<bool> DeleteOneAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser is not null)
            {
                return await _userRepo.DeleteOneAsync(foundUser);
            }
            return false;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllAsync(GetAllOptions getAllOptions)
        {
            var userList = await _userRepo.GetAllAsync(getAllOptions);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserReadDto>>(userList);
        }

        public async Task<UserReadDto> GetByIdAsync(Guid id)
        {
            var foundUser = await _userRepo.GetByIdAsync(id);
            if (foundUser is null)
            {
                throw CustomException.NotFound($"User with {id} is not found");
            }
            return _mapper.Map<User, UserReadDto>(foundUser);
        }

        public async Task<bool> UpdateOneAsync(Guid id, UserUpdateDto updateDto)
        {
            var foundItem = await _userRepo.GetByIdAsync(id) ?? throw CustomException.NotFound($"User with {id} is not found");
            if (foundItem == null)
            {
                return false;
            }
            _mapper.Map(updateDto, foundItem);
            return await _userRepo.UpdateOneAsync(foundItem);
        }
    }
}