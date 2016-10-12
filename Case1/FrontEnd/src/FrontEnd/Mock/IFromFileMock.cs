using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace FrontEnd.Mock
{
    public class IFromFileMock : IFormFile
    {
        public string ContentDisposition
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ContentType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string FileName
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IHeaderDictionary Headers
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void CopyTo(Stream target)
        {
            throw new NotImplementedException();
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Stream OpenReadStream()
        {
            throw new NotImplementedException();
        }
    }
}
