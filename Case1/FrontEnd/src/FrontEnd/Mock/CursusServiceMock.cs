using FrontEnd.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontEnd.Agents.Models;
using Microsoft.Rest;
using Newtonsoft.Json;
using System.Threading;

namespace FrontEnd.Mock
{
    public class CursusServiceMock : ServiceClient<CursusService>, ICursusService
    {
        private List<CursusInstantie> _cursussen;

        public CursusServiceMock()
        {
            _cursussen = new List<CursusInstantie>();
            _cursussen.Add(new CursusInstantie { Id = 2, Cursus = new Cursus { Id = 1, Code = "CNETIN", Titel = "C# programmeren", Duur = 5 }, Startdatum = "13/10/2016" });
            _cursussen.Add(new CursusInstantie { Id = 1, Cursus = new Cursus { Id = 2, Code = "ABC", Titel = "Test", Duur = 2 }, Startdatum = "12/10/2016" });
            _cursussen.Add(new CursusInstantie { Id = 3, Cursus = new Cursus { Id = 3, Code = "XYZ", Titel = "The end of alphabet", Duur = 3 }, Startdatum = "11/10/2016" });
        }

        public bool PostIsCalled { get; set; }

        public Uri BaseUri
        {
            get
            {
                return new Uri(@"http://Localhost/");
            }

            set
            {

            }
        }

        public JsonSerializerSettings DeserializationSettings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public JsonSerializerSettings SerializationSettings
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Task<HttpOperationResponse<CursusInstantie>> ApiV1CursusByIdGetWithHttpMessagesAsync(int id, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<HttpOperationResponse<IList<CursusInstantie>>> ApiV1CursusGetWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Factory.StartNew<HttpOperationResponse<IList<CursusInstantie>>>(() =>
            {
                var res = new HttpOperationResponse<IList<CursusInstantie>>();
                res.Body = _cursussen;
                return res;
            });
        }

        public Task<HttpOperationResponse<object>> ApiV1CursusPostWithHttpMessagesAsync(IList<CursusInstantie> cursus = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            PostIsCalled = true;
            return Task.Factory.StartNew<HttpOperationResponse<object>>(() =>
            {
                var res = new HttpOperationResponse<object>();
                int count = cursus.Count();
                res.Body = new PostSuccess { Total = count };
                return res;
            });
        }
    }
}
