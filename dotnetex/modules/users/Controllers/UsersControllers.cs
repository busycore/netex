using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using dotnetex.modules.users.Services.Implementations.GetAllUsersService;
using dotnetex.shared.Providers.FileUploadProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using modules.users.Models;
using modules.users.Services;
using shared.Configurations.Database;

namespace modules.users.Controllers
{
    [ApiController]
    [Route("/user")]
    //[Route("[controller]")] -> Will use the class name as route
    //[Route("[controller]/[action]")] -> will use classname/methodname as path
    public class UsersControllers : ControllerBase
    {
        private readonly UserServices userServices;

        private readonly ILogger<UsersControllers> _logger;

        public UsersControllers(SQLiteDbContext context, UserServices userServices, ILogger<UsersControllers> logger)
        {
            this._logger = logger;
            this.userServices = userServices;
        }

        [HttpGet]
        public List<Users> getAllUsers()
        {
            return this.userServices.GetAllUsers();
        }

        [HttpOptions("second")]
        public List<Users> getAllUsersAlternative([FromServices] IServiceProvider serviceProvider)
        {
            //Injecting/Resolving on the fly
            var service = (IGetAllUsersService)serviceProvider.GetService(typeof(IGetAllUsersService));
            return service.execute();
        }

        [HttpOptions("third")]
        public List<Users> getAllUsersThird([FromServices] IGetAllUsersService GetAllUsersService)
        {
            return GetAllUsersService.execute();
        }


        [HttpGet("{id}")]
        public Users getSingleUser(int id)
        {
            return this.userServices.GetUserById(id);
        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            this.userServices.DeleteUser(id);
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpPost]
        public Users makeUser([FromBody] Users user)
        {
            return this.userServices.createUser(user);
        }

        [HttpPost("upload")]
        public string uploadFile([FromForm] IFormFile arquivo, [FromServices] IFileUpload fileUpload)
        {
            var abc = arquivo.OpenReadStream();
            _logger.LogInformation(arquivo.FileName);
            return "oi";
            //return await fileUpload.Upload(arquivo);
            //return this.userServices.createUser(user);
        }

        [HttpPost("uploadS3")]
        public async Task<string> uploadFileS3([FromForm] IFormFile arquivo)
        {
            //*Setup S3 Client
            var newRegion = RegionEndpoint.GetBySystemName("us-west-new");

            var config = new AmazonS3Config { ServiceURL = "http://localhost:4566" };
            var s3 = new AmazonS3Client(config);

            // //*List Buckets

            // var response = await s3.ListBucketsAsync();

            // var ListOfBuckets = response.Buckets.Select(bck => bck.BucketName + " - " + bck.CreationDate).ToList();
            // foreach (S3Bucket bucket in response.Buckets)
            // {
            //     _logger.LogInformation(bucket.BucketName);

            // }

            //await s3.PutBucketAsync("Olop");
            try
            {


                var putRequest1 = new PutObjectRequest
                {
                    BucketName = "fileplace",
                    Key = "asd",
                    ContentBody = "sample text"
                };

                PutObjectResponse response1 = await s3.PutObjectAsync(putRequest1);
                _logger.LogInformation(response1.ToString());
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine(
                        "AWS - Error encountered ***. Message:'{0}' when writing an object"
                        , e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    "Unknown encountered on server. Message:'{0}' when writing an object"
                    , e.Message);
            }


            // //* File Upload
            // var fsz = arquivo.OpenReadStream();
            // //fsz.Position = 0;

            // //* Create a Request
            // var request = new PutObjectRequest()
            // {
            //     BucketName = "fileplace",
            //     Key = arquivo.FileName,
            //     //ContentType = arquivo.ContentType,
            //     //CannedACL = S3CannedACL.PublicRead,
            //     //InputStream = fsz,
            //     ContentBody = "Olá"
            // };


            // var objrsp = await s3.PutObjectAsync(request);
            // var Laresult = string.Format("http://{0}.s3.amazonaws.com/{1}", request.BucketName, request.Key);

            //_logger.LogInformation(Laresult);

            return "ListOfBuckets";
            //return await fileUpload.Upload(arquivo);
            //return this.userServices.createUser(user);
        }
    }
}