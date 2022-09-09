using ApiConnector.Dto;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace ApiConnector {
    public class ApiConnector {
        internal string DefaultCon = "pbskamdud000.tk";
        internal int Port = 3000;

        private static Lazy<ApiConnector> instance =
        new Lazy<ApiConnector>(() => new ApiConnector());
        public static ApiConnector Instance => instance.Value;


        internal readonly RestClient _client;


        private ApiConnector() {
            var options = new RestClientOptions($"http://{DefaultCon}:{Port}") {
                ThrowOnAnyError = true,
                MaxTimeout = 1000
            };
            _client = new RestClient(options);
            _client.UseSystemTextJson(new JsonSerializerOptions(JsonSerializerDefaults.Web));

        }

        public Task<List<GameDto>?> GetGames() {
            var request = new RestRequest("games");
            return _client.GetAsync<List<GameDto>>(request);
        }

        public Task<GameDto?> UpdateGame(GameDto gameDto) {
            var resource = $"games/{gameDto.Id}";

            var body = new {
                Name = gameDto.Name
            };
            
            return _client.PostJsonAsync<object, GameDto>(resource, gameDto);
        }

        public Task CreateGame(GameDto gameDto) {
            var resource = "games";
            return _client.PutJsonAsync<object, GameDto>(resource, gameDto);
        }

        public Task DeleteGame(long id) {
            var resource = $"games/{id}";
            var request = new RestRequest(resource);
            return _client.DeleteAsync(request);
        }


    }
}