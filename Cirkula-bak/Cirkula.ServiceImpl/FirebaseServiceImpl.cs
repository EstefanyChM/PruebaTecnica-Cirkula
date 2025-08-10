using Cirkula.Services;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.Extensions.Configuration;
namespace Cirkula.ServiceImpl
{
	public class FirebaseServiceImpl : FirebaseService
    {
        private readonly string _email;
        private readonly string _password;
        private readonly string _bucket;
        private readonly string _apiKey;
    
        public FirebaseServiceImpl(IConfiguration config)
        {
            _email = config["Firebase:Email"];
            _password = config["Firebase:Password"];
            _bucket = config["Firebase:Bucket"];
            _apiKey = config["Firebase:ApiKey"];
        }
    
        public async Task<string> UploadFileAsync(Stream file, string fileName, string folder)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(_email, _password);
    
            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(
                _bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(folder)
                .Child(fileName)
                .PutAsync(file, cancellation.Token);
    
            return await task;
        }
    }
}
