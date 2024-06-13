using AutoMapper;
using ISTCOSA.Application.CommandAndQuries.UserProfile.Commands;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ISTCOSA.Infrastructure.Handlers.UserProfileHandler
{
    public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserRegisterDTOs>
    {
        private readonly IApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UpdateUserProfileCommandHandler(IApplicationDBContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<UserRegisterDTOs> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var existingPhone = await _context.userRegisters.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Id != request.Id);
            if (existingPhone != null) throw new Exception("Phone Number has Already used by Someone");
            var existingEmail = await _context.userRegisters.FirstOrDefaultAsync(x => x.Email == request.Email && x.Id != request.Id);
            if (existingEmail != null) throw new Exception("Email has Already used by Someone");
            string newImagePath = null;
            if (!string.IsNullOrEmpty(request.Images))
            {
                var ext = request.ImageType;
                newImagePath = SaveImage(request.Images,ext);
            }
            var existingUser = await _context.userRegisters.FindAsync(request.Id);
            if (existingUser == null) throw new Exception("User Not Found");

            if (!string.IsNullOrEmpty(request.Images) && !string.IsNullOrEmpty(existingUser.Images))
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", Path.GetFileName(existingUser.Images));
                if (File.Exists(oldImagePath))
                {
                    File.Delete(oldImagePath);
                }
            }
            existingUser.FullName = request.FullName;
            existingUser.Gender = request.Gender;
            existingUser.Email = request.Email;
            existingUser.PhoneNumber = request.PhoneNumber;
            existingUser.NormalizedEmail = request.Email.ToUpper();
            existingUser.DateOfBirth = request.DateOfBirth;
            existingUser.Images = newImagePath ?? existingUser.Images;
            existingUser.UpdatedDateAndTime = DateTime.Now;
            existingUser.CityId = request.CityId;
            _context.Update(existingUser);
            await _context.SaveChangesAsync();

            var mappedUserForUpdate = _mapper.Map<UserRegisterDTOs>(existingUser);
            return mappedUserForUpdate;
        }

        private string SaveImage(string base64Image, string ImageType)
        {
            if (string.IsNullOrWhiteSpace(base64Image))
            {
                throw new ArgumentException("Invalid image data");
            }

            string data = base64Image;
            byte[] imageBytes;
            try
            {
                imageBytes = Convert.FromBase64String(data);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Invalid base64 image data");
            }

            using (var ms = new MemoryStream(imageBytes))
            {
                try
                {
                    var image = System.Drawing.Image.FromStream(ms);
                }
                catch (Exception)
                {
                    throw new ArgumentException("Invalid image format");
                }
            }

            // Extract file extension from ImageType
            var fileExtension = Path.GetExtension(ImageType);
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentException("Invalid image type or missing file extension");
            }

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllBytes(filePath, imageBytes);
            return fileName;
        }

    }
}

